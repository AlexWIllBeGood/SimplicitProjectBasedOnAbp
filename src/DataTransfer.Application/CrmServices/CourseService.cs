using DataTransfer.Application.Contracts.Dtos.InputDtos;
using DataTransfer.Domain;
using DataTransfer.Domain.Entities.CrmEntities;
using DataTransfer.Domain.Entities.LocalEntities;
using DataTransfer.Domain.Entities.Temp;
using DataTransfer.Domain.Shared.Enums;
using DataTransfer.EntityFramework.Repositories;
using DataTransfer.EntityFramework.Repositories.CrmRepositories;
using DataTransfer.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DataTransfer.Application.CrmServices
{
    public class CourseService : ApplicationService
    {
        private const int NewConceptProd = 3;
        private const string ClassCode_FZ_NCE = "FZ-LNCE";
        private readonly IOptionsMonitor<CRMOptions> _classOptions;
        private readonly ClassCourseRepository _classCourseRepository;
        private readonly ProductLevelRepository _productLevelRepository;
        private readonly LeadRepository _leadRepository;
        private readonly ProductRepository _productRepository;
        private readonly ProductRelationRepository _productRelationRepository;
        private readonly ContractRepository _contractRepository;
        private readonly ClassRelationRepository _classRelationRepository;
        private readonly TransferLogRepository _transferLogRepository;
        private readonly ClassTeacherRepository _classTeacherRepository;
        private readonly UserRepository _userRepository;
        private readonly BranchRepository _branchRepository;
        private readonly ClassHourLevelRepository _classHourLevelRepository;
        public CourseService(
            IOptionsMonitor<CRMOptions> classOptions,
            ClassCourseRepository classCourseRepository,
            ProductLevelRepository productLevelRepository,
            LeadRepository leadRepository,
            ContractRepository contractRepository,
            ProductRepository productRepository,
            ProductRelationRepository productRelationRepository,
            ClassRelationRepository classRelationRepository,
            TransferLogRepository transferLogRepository,
            ClassTeacherRepository classTeacherRepository,
            UserRepository userRepository,
            BranchRepository branchRepository,
            ClassHourLevelRepository classHourLevelRepository
            )
        {
            this._classOptions = classOptions;
            this._classCourseRepository = classCourseRepository;
            this._productLevelRepository = productLevelRepository;
            this._leadRepository = leadRepository;
            this._contractRepository = contractRepository;
            this._productRepository = productRepository;
            this._productRelationRepository = productRelationRepository;
            this._classRelationRepository = classRelationRepository;
            this._transferLogRepository = transferLogRepository;
            this._classTeacherRepository = classTeacherRepository;
            this._userRepository = userRepository;
            this._branchRepository = branchRepository;
            this._classHourLevelRepository = classHourLevelRepository;
        }
        /// <summary>
        /// 发送班级数据到MTS
        /// </summary>
        /// <returns></returns>
        public async Task<string> SendClassToMtsAsync(int productType, int branchId, int clasStatus, DateTime? beginTimeDate, DateTime? endTimeDate, string SAId, string FTId, string LTId)
        {
            try
            {
                var targetClasses = await _classCourseRepository
                .Include(e => e.ClassSchedules)
                .Include(e => e.Product)
                .Include(e => e.Branch)
                .Include(e => e.SA)
                .Include(e => e.LT)
                .Include(e => e.FT)
                .Include(e => e.ClassStudents)
                .Where(e =>
                e.Product.Prod_Type == productType
                && e.Clas_BranID == branchId
                && e.Clas_Status == clasStatus
                && e.Clas_Deleted == 0
                && e.Clas_ActualBeginDate > beginTimeDate
                && e.Clas_ActualBeginDate <= endTimeDate
                ).ToListAsync();

                List<string> pls = targetClasses.Select(e => e.Product.Prod_Levels).ToList();
                List<string> plsIds = new List<string>();
                foreach (var pl in pls)
                {
                    List<string> plIds = pl.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
                    plsIds = plsIds.Union(plIds).ToList();
                }
                List<int> pliIds = plsIds.Select<string, int>(e => Convert.ToInt32(e)).ToList();
                List<CrmProductLevel> productLevels = _productLevelRepository.Where(e => pliIds.Contains(e.Prol_ID)).ToList();
                List<ClassSendMtsModel> clsses = new List<ClassSendMtsModel>();
                foreach (var tc in targetClasses)
                {
                    var product = await GetNewProductByOriginProductAsync(tc.Product);
                    var model = new ClassSendMtsModel();
                    model.SchoolId = tc.Branch.Bran_SapId;
                    model.ProductId = product.Prod_Type;
                    model.ClassTypeId = product.Prod_SubTypeID;
                    model.ProductLevelId = await GetCurrentProductLevelOfClassAsync(tc);
                    model.ClassCName = tc.Clas_Code;
                    //model.SAId = tc.SA?.User_Logon ?? "jennifer_jy";
                    model.SAId = SAId;
                    model.HasFT = true;
                    model.FTId = FTId;
                    model.HasLT = true;
                    model.LTId = LTId;
                    //model.HasFT = tc.FT != null;
                    //model.FTId = tc.FT?.User_Logon;
                    //model.HasLT = tc.LT != null;
                    //model.LTId = tc.LT?.User_Logon;
                    model.ClassOpenDate = tc.Clas_ActualBeginDate?.ToString("yyyy-MM-dd");
                    //处理上课时间的内容
                    List<SimpleClassSchedule> scss = new List<SimpleClassSchedule>();
                    scss = JsonConvert.DeserializeObject<List<SimpleClassSchedule>>(tc.Clas_Schedule);
                    StringBuilder scheduleBuilder = new StringBuilder();
                    foreach (var scs in scss)
                    {
                        scheduleBuilder.Append($"{scs.Week}*{scs.BeginTime}*{scs.EndTime}&");
                    }
                    model.CourseTimes = scheduleBuilder.ToString().TrimEnd('&');
                    clsses.Add(model);
                }
                int successCount = 0;

                DateTime now = DateTime.Now;
                string batchNo = $"{DataTransferConst.ClassTransferNo}{now.ToString("yyyyMMddHHmmss")}";
                foreach (var c in clsses)
                {
                    var response = HttpHelper.PostAsync<ClassMRTSResponseEntity>(_classOptions.CurrentValue.ClassSendMTSUrl, c);
                    if (response.ResultCode == "100000"
                        || response.ResultCode == "100002")
                    {
                        successCount++;
                        //保存classRelation的关系
                        var crmClassId = targetClasses.FirstOrDefault(e => e.Clas_Code == c.ClassCName)?.Clas_ID;
                        var existClassRelation = await _classRelationRepository.FirstOrDefaultAsync(e => e.CrmClassId == crmClassId);
                        if (existClassRelation != null)
                        {
                            existClassRelation.MTSClassId = response.MTSClassId;
                            await _classRelationRepository.UpdateAsync(existClassRelation);
                        }
                        else
                        {
                            await _classRelationRepository.InsertAsync(new ClassRelation()
                            {
                                CrmClassId = crmClassId,
                                MTSClassId = response.MTSClassId
                            });
                        }
                    }
                    //保存日志
                    await _transferLogRepository.InsertAsync(new TransferLog()
                    {
                        BatchNo = batchNo,
                        Para = JsonConvert.SerializeObject(c),
                        Response = JsonConvert.SerializeObject(response),
                        Type = TransferLogType.Class,
                        CreateTime = DateTime.Now
                    });
                }
                return $"Class Trasfer info:Total:{clsses.Count} Success:{successCount} Fail:{clsses.Count - successCount}";
            }
            catch (Exception ex)
            {

                return "error";
            }
            
        }
        /// <summary>
        /// 设置班级进度
        /// </summary>
        /// <param name="productType"></param>
        /// <param name="branchId"></param>
        /// <param name="clasStatus"></param>
        /// <param name="beginTimeDate"></param>
        /// <param name="endTimeDate"></param>
        /// <returns></returns>
        public async Task<string> SetClassProcessAsync(int productType, int branchId, int clasStatus, DateTime? beginTimeDate, DateTime? endTimeDate)
        {
            var targetClasses = await _classCourseRepository
                .Include(e => e.ClassSchedules)
                .Include(e => e.Product)
                .Include(e => e.Branch)
                .Include(e => e.SA)
                .Include(e => e.LT)
                .Include(e => e.FT)
                .Include(e => e.ClassStudents)
                .Where(e =>
                e.Product.Prod_Type == productType
                && e.Clas_BranID == branchId
                && e.Clas_Status == clasStatus
                && e.Clas_Deleted == 0
                && e.Clas_ActualBeginDate > beginTimeDate
                && e.Clas_ActualBeginDate <= endTimeDate
                ).ToListAsync();

            var classRelations = await _classRelationRepository.GetListAsync();
            var models = new List<SetClassProcessModel>();
            foreach (var tc in targetClasses)
            {
                var mtsClassId = classRelations.FirstOrDefault(e => e.CrmClassId == tc.Clas_ID)?.MTSClassId;
                var remainHour = await GetRemainHourOfClass(tc);
                models.Add(new SetClassProcessModel()
                {
                    ClassId = mtsClassId,
                    LessonPeriod = remainHour
                });
            }

            var successCount = 0;
            DateTime now = DateTime.Now;
            string batchNo = $"{DataTransferConst.ProcessTransferNo}{now.ToString("yyyyMMddHHmmss")}";
            foreach (var m in models)
            {
                var response = HttpHelper.PostAsync<CommonMTSResponseEntity>(_classOptions.CurrentValue.ClassProcessSetUrl, m);
                if (response.ResultCode == "000000")
                    successCount++;

                //保存日志
                await _transferLogRepository.InsertAsync(new TransferLog()
                {
                    BatchNo = batchNo,
                    Para = JsonConvert.SerializeObject(m),
                    Response = JsonConvert.SerializeObject(response),
                    Type = TransferLogType.ClassProcess,
                    CreateTime = DateTime.Now
                });
            }
            return $"ClassProcessSet Trasfer info:Total:{models.Count} Success:{successCount} Fail:{models.Count - successCount}";
        }
        /// <summary>
        /// 发送学生合同信息到MTS
        /// </summary>
        /// <returns></returns>
        public async Task<string> SendStudentToMtsAsync(int productType, int branchId, int clasStatus, DateTime? beginTimeDate, DateTime? endTimeDate)
        {
            try
            {
                var targetClasses = await _classCourseRepository
                    .Include(e=>e.ClassStudents)
                    .Include(e => e.ClassSchedules)
                    .Where(e =>
                    e.Product.Prod_Type == productType
                    && e.Clas_BranID == branchId
                    && e.Clas_Status == clasStatus
                    && e.Clas_Deleted == 0
                    && e.Clas_ActualBeginDate > beginTimeDate
                    && e.Clas_ActualBeginDate <= endTimeDate
                    ).ToListAsync();
                var classIds = targetClasses.Select(e => e.Clas_ID).ToList();
                var classStudents = targetClasses.SelectMany(e => e.ClassStudents).ToList();
                //查找所有相关的合同
                var allContracts = _contractRepository
                    .Include(e => e.ClassCourse)
                    .Include(e => e.Product)
                    .Include(e => e.Lead)
                    .ThenInclude(e => e.Branch)
                    .Include(e => e.Order)
                    .ThenInclude(e => e.CC)
                    .Where(e => classIds.Contains((int)e.Cont_ClassId)
                    && e.Cont_Status == 2
                    && e.Cont_LeadId != null
                    && e.Cont_ProductID != null
                    && e.Cont_OrderID != null
                    && e.Cont_ClassId != null
                    && e.Cont_Deleted == 0
                    )
                    .ToList();

                //根据合同获取所有相关的班级对应信息
                var allCrmClassIds = allContracts.Select(e => e.Cont_ClassId).Distinct();
                var allClassRelations = _classRelationRepository
                    .Where(e => allCrmClassIds.Contains(e.CrmClassId))
                    .ToList();

                //将相关合同按照签约人，产品，订单划分
                //按照班级（产品去进行分组，实际上一个班级只会有一个产品）
                var contractGroups = allContracts
                    .GroupBy(e => new { e.Cont_LeadId, e.Cont_ProductID, e.Cont_ClassId })
                    .Select(e => new
                    {
                        e.Key.Cont_LeadId,
                        e.Key.Cont_ProductID,
                        e.Key.Cont_ClassId,
                        Count = e.Count()
                    })
                    .ToList();

                //var target = contractGroups.Where(e => e.Cont_LeadId == 296).ToList();
                List<CrmStudentInfoModel> models = new List<CrmStudentInfoModel>();
                foreach (var cg in contractGroups)
                {
                    var cs = classStudents.FirstOrDefault(e =>
                    (e.Clst_Status == 0 || e.Clst_Status == 1)
                    && e.Clst_LeadID == cg.Cont_LeadId
                    && e.Clst_ClassID == cg.Cont_ClassId
                    && e.Clst_Deleted == 0
                        );

                    //不存在合适的班级学员数据则退出
                    if (cs == null)
                        continue;

                    var contracts = allContracts
                        .Where(e => e.Cont_LeadId == cg.Cont_LeadId
                        && e.Cont_ProductID == cg.Cont_ProductID
                        && e.Cont_ClassId == cg.Cont_ClassId)
                        .OrderBy(e => e.Cont_CreatedDate)
                        .ToList();

                    var sumClassHour = contracts.Sum(e => e.Cont_ClassHour) * 3;
                    //这里必须取四舍五入
                    var plCount = Convert.ToInt32(Math.Round((decimal)sumClassHour / 42));
                    var tc = targetClasses.FirstOrDefault(e => e.Clas_ID == cg.Cont_ClassId);
                    var contract = contracts.FirstOrDefault();
                    var order = contract.Order;
                    var lead = contract.Lead;
                    var classCourse = contract.ClassCourse;
                    var cc = order.CC;
                    var branch = lead.Branch;
                    var product = await GetNewProductByOriginProductAsync(contract.Product);
                    var productLevels = await GetStudentProductLevelsOfClassAsync(tc, cs);
                    var beginLevel = productLevels[0];
                    var currentLevel = productLevels[0];
                    var endLevel = productLevels[productLevels.Count - 1];
                    DateTime contractBeginTime = contract?.Cont_BegDate ?? DateTime.Now;
                    DateTime contractEndTime = contractBeginTime.AddMonths((int)6 * productLevels.Count());
                    CrmStudentInfoModel model = new CrmStudentInfoModel();

                    model.platfromKey = _classOptions.CurrentValue.MTSPlatformKey;
                    model.userName = lead?.Lead_LeadID.ToString();
                    model.email = lead?.Lead_Email;
                    model.cName = lead?.Lead_Name;
                    model.eName = lead?.Lead_EnName;
                    model.gender = lead?.Lead_Gender == 0 ? 1 : 0;
                    model.birthday = lead?.Lead_Birthday;
                    model.mobile = lead?.Lead_Mobile;
                    model.branchId = lead?.Branch?.Bran_SapId;
                    model.ccUserId = cc?.User_Logon;
                    model.contractId = contract?.Cont_ContractID;
                    model.emeId = lead?.Lead_LeadID;
                    model.contractNum = contract?.Cont_Number;
                    model.cont_isbinding = null;
                    model.contractType = product.Prod_Type.ToString();
                    model.contractBranchId = branch?.Bran_SapId.ToString();
                    model.contBeginDate = contractBeginTime;
                    model.contEndDate = contractEndTime;
                    model.contStatus = "02"; //02 执行、03冻结、06结束、01结束
                    model.productId = product?.Prod_ID;
                    model.productType = product.Prod_Type;
                    model.beginProductLevelId = beginLevel;
                    model.endProductLevelId = endLevel;
                    model.currentLevel = currentLevel;
                    model.productLevelId = string.Join(",", productLevels);
                    model.contractShift = "Contract";
                    model.Cont_ParentId = null;
                    model.Cont_ShiftType = "Contract";
                    model.Cont_reason = null;
                    model.Cont_RefundAmount = 0;
                    model.ccUserName = cc?.User_Logon;
                    model.classId = allClassRelations.FirstOrDefault(e => e.CrmClassId == contract.Cont_ClassId)?.MTSClassId;
                    model.levelCodes = string.Join(",", productLevels);
                    model.currLevelCodes = currentLevel;
                    model.contractTypeSub = product.Prod_SubTypeID;
                    if (clasStatus == 1)
                    {
                        model.remark = $"{DateTime.Now.ToString("yyyy年MM月dd日 HH:mm分")}导入，老系统课时{sumClassHour}，新系统{plCount * 42}，差额{sumClassHour - plCount * 42}.";
                    }
                    models.Add(model);
                }
                var successCount = 0;
                DateTime now = DateTime.Now;
                string batchNo = $"{DataTransferConst.StudentTransferNo}{now.ToString("yyyyMMddHHmmss")}";
                foreach (var m in models)
                {
                    var response = HttpHelper.PostAsync<CommonMTSResponseEntity>(_classOptions.CurrentValue.OrderSendMTSUrl, m);
                    if (response.ResultCode == "000000")
                        successCount++;

                    //保存日志
                    await _transferLogRepository.InsertAsync(new TransferLog()
                    {
                        BatchNo = batchNo,
                        Para = JsonConvert.SerializeObject(m),
                        Response = JsonConvert.SerializeObject(response),
                        Type = TransferLogType.Student,
                        CreateTime = DateTime.Now
                    });
                }
                return $"Student Trasfer info:Total:{models.Count} Success:{successCount} Fail:{models.Count - successCount}";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// 添加教师名称
        /// </summary>
        /// <returns></returns>
        public async Task<string> AddTeacherNameAsync()
        {
            var cts = await _classTeacherRepository
                .GetListAsync();

            var classIds = cts.Select(e => e.ClassId)
                .ToList();

            var classes = await _classCourseRepository
                .Where(e => classIds.Contains(e.Clas_ID))
                .ToListAsync();

            foreach (var c in classes)
            {
                List<int> emptyClassIds = new List<int>();
                var LTId = cts.FirstOrDefault(e => e.ClassId == c.Clas_ID)?.TeacherId;
                if (LTId != null)
                {
                    c.Clas_LT = LTId;
                    await _classCourseRepository.UpdateAsync(c);
                }
                emptyClassIds.Add(c.Clas_ID);
            }

            return "";
        }
        /// <summary>
        /// 查找对应教师，班级数据
        /// </summary>
        /// <returns></returns>
        public async Task<string> FindTeacherClassAsync()
        {
            try
            {
                var classTeachers = await _classTeacherRepository.GetListAsync();
                List<string> bcodes = new List<string>();
                List<string> tcodes = new List<string>();
                List<string> ccodes = new List<string>();
                foreach (var ct in classTeachers)
                {
                    var branches = await _branchRepository.
                        Where(e => e.Bran_Name == ct.BranchName
                        && e.Bran_Deleted == 0
                        )
                        .ToListAsync();

                    var teachers = await _userRepository.
                        Include(e => e.Branch)
                        .Where(e => e.User_CnName == ct.TeacherName
                        && e.User_Deleted == 0
                        //&& e.Branch.Bran_Name == ct.BranchName
                        )
                        .ToListAsync();
                    var classes = await _classCourseRepository
                        .Where(e => e.Clas_Code == ct.ClassName
                        && e.Clas_Deleted == 0
                        )
                        .ToListAsync();

                    if (teachers.Count() != 1
                        || branches.Count() != 1
                        || classes.Count() != 1)
                    {
                        tcodes.Add(ct.ClassName);
                    }
                    else
                    {
                        var t = teachers.FirstOrDefault();
                        var b = branches.FirstOrDefault();
                        var c = classes.FirstOrDefault();
                        ct.TeacherId = t.User_ID;
                        ct.BranchId = b.Bran_ID;
                        ct.ClassId = c.Clas_ID;
                        await _classTeacherRepository.UpdateAsync(ct);
                    }
                }

                return "";
            }
            catch (Exception ex)
            {

                return "error";
            }
        }

        #region 私有方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private async Task<CrmProduct> GetNewProductByOriginProductAsync(CrmProduct product)
        {
            var newName = (await _productRelationRepository.FirstOrDefaultAsync(
                e => e.OriginalProductName == product.Prod_Name.Replace(" ", "")
                ))?.NewProductName;

            return await _productRepository.FirstOrDefaultAsync(e => e.Prod_Name == newName);
        }
        /// <summary>
        /// 获取班级的当前
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        private async Task<string> GetCurrentProductLevelOfClassAsync(CrmClassCourse cc)
        {
            var plCount = Convert.ToInt32(Math.Round((decimal)cc.Clas_ClassHour * 3 / 42));
            var plNames = await GetProductLevelsOfClassAsync(cc, plCount);
            var waitHour = cc.ClassSchedules.Count(e => e.Clsc_Status == 0 && e.Clsc_Deleted == 0);
            var startIndex = plNames.Count - Convert.ToInt32(Math.Floor((decimal)waitHour * 3 / 42));
            //这里的判断原因是可能会出现“临界点数据”
            startIndex = startIndex == 0 ? 1 : startIndex;
            if (startIndex < 1 || startIndex > plNames.Count)
            {
                var a = 1;
            }
            return plNames[startIndex - 1];
        }
        /// <summary>
        /// 获取班级剩余课时（逻辑正确）
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        private async Task<int> GetRemainHourOfClass(CrmClassCourse cc)
        {
            var waitHour = cc.ClassSchedules.Count(e => e.Clsc_Status == 0 && e.Clsc_Deleted == 0);
            return await Task.FromResult((waitHour * 3) % 42);
        }
        /// <summary>
        /// 获取班级的所有级别
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        private async Task<List<string>> GetProductLevelsOfClassAsync(CrmClassCourse cc, int? plCount=null)
        {
            List<string> plNames = new List<string>();
            var newProduct = await GetNewProductByOriginProductAsync(cc.Product);
            var plIds = newProduct.Prod_Levels.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().Select<string, int>(e => int.Parse(e));
            if (plCount == null)
            {
                plNames = await _productLevelRepository.Where(e => plIds.Contains(e.Prol_ID)).Select(e => e.Prol_Name).OrderBy(e => e).ToListAsync();
            }
            else
            {
                plNames = await _productLevelRepository.Where(e => plIds.Contains(e.Prol_ID)).Select(e => e.Prol_Name).OrderBy(e => e).Take((int)plCount).ToListAsync();
            }
            return plNames;
        }
        /// <summary>
        /// 获取学生的产品级别
        /// </summary>
        /// <returns></returns>
        private async Task<List<string>> GetStudentProductLevelsOfClassAsync(CrmClassCourse cc,CrmClassStudent cs)
        {
            //学生剩余的整级别
            var plCount = Convert.ToInt32(Math.Round((decimal)(cs.Clst_ClassHour - cs.Clst_AdjustHour - cs.Clst_FinishHour) * 3 / 42));
            var allPlNames = await GetProductLevelsOfClassAsync(cc);
            var currentPlName = await GetCurrentProductLevelOfClassAsync(cc);
            var startIndex = allPlNames.IndexOf(currentPlName);
            var plNames = allPlNames.Skip(startIndex).Take(plCount + 1).ToList();
            return plNames;
        }
        #endregion
    }
}
