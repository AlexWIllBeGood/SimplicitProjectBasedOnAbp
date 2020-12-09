using DataTransfer.Application.Contracts.IApplicationServices;
using DataTransfer.Domain;
using DataTransfer.Domain.Entities.CrmEntities;
using DataTransfer.Domain.Entities.ElasticSearch;
using DataTransfer.Domain.Entities.LocalEntities;
using DataTransfer.Domain.Entities.Temp;
using DataTransfer.Domain.IRepositories.ICrmRepositories;
using DataTransfer.Domain.IRepositories.ILocalRepositories;
using DataTransfer.Domain.Shared.Enums;
using DataTransfer.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Uow;

namespace DataTransfer.Application.CrmServices
{
    public class ClassStudentApplicationService : BaseApplicationService, IClassStudentApplicationService
    {
        private readonly IOptions<CRMOptions> _classOptions;
        private readonly IBranchRepository _branchRepository;
        private readonly IProductLevelRepository _productLevelRepository;
        private readonly IClassRelationRepository _classRelationRepository;
        private readonly ITransferLogRepository _transferLogRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductRelationRepository _productRelationRepository;
        public ClassStudentApplicationService(
            IOptions<CRMOptions> classOptions,
            IBranchRepository branchRepository,
            IProductLevelRepository productLevelRepository,
            IClassRelationRepository classRelationRepository,
            ITransferLogRepository transferLogRepository,
            IContractRepository contractRepository,
            IProductRepository productRepository,
            IProductRelationRepository productRelationRepository,
            IUnitOfWorkManager unitOfWorkManager
            ):base(unitOfWorkManager)
        {
            this._classOptions = classOptions;
            this._branchRepository = branchRepository;
            this._productLevelRepository = productLevelRepository;
            this._classRelationRepository = classRelationRepository;
            this._transferLogRepository = transferLogRepository;
            this._contractRepository = contractRepository;
            this._productRepository = productRepository;
            this._productRelationRepository = productRelationRepository;
        }

        public async Task<string> SendClassToMtsAsync(int productType, int branchId, List<CrmClassCourse> targetClasses, int classPerLevel, string SAId, string FTId, string LTId)
        {
            try
            {
                var branch = await _branchRepository.FirstOrDefaultAsync();

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
                    model.ProductLevelId = await GetCurrentProductLevelOfClassAsync(tc, classPerLevel);
                    model.ClassCName = tc.Clas_Code;
                    //model.SAId = tc.SA?.User_Logon ?? "jennifer_jy";
                    model.SAId = SAId;
                    model.HasFT = true;
                    model.FTId = FTId;
                    model.HasLT = true;
                    //中教没有就使用默认的
                    model.LTId = tc.LT?.User_Logon ?? LTId;
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
                        var beginTime = Convert.ToDateTime(scs.BeginTime);
                        var endTime = Convert.ToDateTime(scs.EndTime);
                        var currentTime = beginTime.AddHours(1);
                        while (true)
                        {
                            scheduleBuilder.Append($"{scs.Week}*{beginTime.ToString("HH:mm")}*{currentTime.ToString("HH:mm")}&");
                            if (currentTime >= endTime)
                                break;
                            beginTime = currentTime;
                            currentTime = currentTime.AddHours(1);
                        }
                    }
                    model.CourseTimes = scheduleBuilder.ToString().TrimEnd('&');
                    clsses.Add(model);
                }
                int successCount = 0;

                DateTime now = DateTime.Now;
                string batchNo = $"{DataTransferConst.ClassTransferNo}{now.ToString("yyyyMMddHHmmss")}";

                TransferLog transferLog = new TransferLog()
                {
                    BatchNo = batchNo,
                    BranchInfo = $"{branch.Bran_ID}-{branch.Bran_Name}-{branch.Bran_SapId}",
                    ProductTypeInfo = $"{productType}",
                    Type = TransferLogType.Class,
                    CreateTime = DateTime.Now
                };
                List<ESClassLog> esLogs = new List<ESClassLog>();
                foreach (var c in clsses)
                {
                    var response = HttpHelper.PostAsync<ClassMRTSResponseEntity>(_classOptions.Value.ClassSendMTSUrl, c);
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
                    transferLog.TransferLogDetails.Add(new TransferLogDetail()
                    {
                        Para = JsonConvert.SerializeObject(c),
                        Response = JsonConvert.SerializeObject(response),
                        ClassInfo = $"{c.ClassTypeId}-{c.ClassCName}"
                    });

                    esLogs.Add(new ESClassLog()
                    {
                        Id = c.ClassCName,
                        Para = c,
                        Response = response
                    });
                }
                transferLog.Count = transferLog.TransferLogDetails.Count;
                await _transferLogRepository.InsertAsync(transferLog);
                await _uow.SaveChangesAsync();
                esLogs.ToES<ESClassLog>();
                return $"Class Trasfer info:Total:{clsses.Count} Success:{successCount} Fail:{clsses.Count - successCount}";
            }
            catch (Exception ex)
            {

                return "error";
            }
        }
        public async Task<string> SendStudentToMtsAsync(int productType, int branchId, List<CrmClassCourse> targetClasses, int classPerLevel, int clasStatus, string classStudentStatus, bool needJoinClass = true)
        {
            try
            {
                var branch = await _branchRepository.FirstOrDefaultAsync(e => e.Bran_ID == branchId);
                var classIds = targetClasses.Select(e => e.Clas_ID).ToList();
                List<CrmClassStudent> classStudents;
                if (string.IsNullOrEmpty(classStudentStatus))
                {
                    classStudents = targetClasses.SelectMany(e => e.ClassStudents).ToList();
                }
                else
                {
                    List<int> classStatusList = classStudentStatus.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray().Select<string, int>(e => Convert.ToInt32(e)).ToList();
                    classStudents = targetClasses.SelectMany(e => e.ClassStudents)
                    .Where(e => classStatusList.Contains(e.Clst_Status))
                    .ToList();
                }
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
                    && (e.Cont_LeadId != null && e.Cont_LeadId != 0)
                    && (e.Cont_ProductID != null && e.Cont_ProductID != 0)
                    && (e.Cont_OrderID != null && e.Cont_OrderID != 0)
                    && (e.Cont_ClassId != null && e.Cont_ClassId != 0)
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
                    e.Clst_LeadID == cg.Cont_LeadId
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
                    var plCount = Convert.ToInt32(Math.Round((decimal)sumClassHour / classPerLevel));
                    var tc = targetClasses.FirstOrDefault(e => e.Clas_ID == cg.Cont_ClassId);
                    var contract = contracts.FirstOrDefault();
                    var order = contract.Order;
                    var lead = contract.Lead;
                    var classCourse = contract.ClassCourse;
                    var cc = order.CC;
                    //var branch = lead.Branch;
                    var product = await GetNewProductByOriginProductAsync(contract.Product);
                    var productLevels = await GetStudentProductLevelsOfClassAsync(tc, cs, classPerLevel);
                    var beginLevel = productLevels[0];
                    var currentLevel = productLevels[0];
                    var endLevel = productLevels[productLevels.Count - 1];
                    DateTime contractBeginTime = contract?.Cont_BegDate ?? DateTime.Now;
                    DateTime contractEndTime = contractBeginTime.AddMonths((int)6 * productLevels.Count());
                    CrmStudentInfoModel model = new CrmStudentInfoModel();

                    model.platformKey = _classOptions.Value.MTSPlatformKey;
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
                        model.remark = $"{DateTime.Now.ToString("yyyy年MM月dd日 HH:mm分")}导入，老系统课时{sumClassHour}，新系统{plCount * classPerLevel}，差额{sumClassHour - plCount * classPerLevel}.";
                    }
                    else if (clasStatus == 2)
                    {
                        var classWaitHour = await GetRemainHourOfClassAsync(tc, classPerLevel);
                        var newWaitHour = classWaitHour + (productLevels.Count - 1) * classPerLevel;
                        var newTotalHour = cs.Clst_FinishHour * 3 + newWaitHour;
                        model.remark = $"{DateTime.Now.ToString("yyyy年MM月dd日 HH:mm分")}导入，老系统课时{sumClassHour}，老系统完成{cs.Clst_FinishHour * 3}，新系统剩余{newWaitHour}，差额{sumClassHour - newTotalHour}.";
                    }
                    model.needJoinClass = needJoinClass;
                    models.Add(model);
                }
                var successCount = 0;
                DateTime now = DateTime.Now;
                string batchNo = $"{DataTransferConst.StudentTransferNo}{now.ToString("yyyyMMddHHmmss")}";
                TransferLog transferLog = new TransferLog()
                {
                    BatchNo = batchNo,
                    BranchInfo = $"{branch.Bran_ID}-{branch.Bran_Name}-{branch.Bran_SapId}",
                    ProductTypeInfo = $"{productType}",
                    Type = TransferLogType.Student,
                    CreateTime = DateTime.Now
                };
                List<ESStudentLog> esLogs = new List<ESStudentLog>();
                foreach (var m in models)
                {
                    var response = HttpHelper.PostAsync<CommonMTSResponseEntity>(_classOptions.Value.OrderSendMTSUrl, m);
                    if (response.ResultCode == "000000")
                        successCount++;

                    transferLog.TransferLogDetails.Add(new TransferLogDetail()
                    {
                        Para = JsonConvert.SerializeObject(m),
                        Response = JsonConvert.SerializeObject(response),
                        LeadInfo = $"{m.cName}-{m.mobile}",
                        ClassInfo = $"{m.classId}"
                    });

                    esLogs.Add(new ESStudentLog()
                    {
                        Id = $"{m.cName}{m.mobile}",
                        Para = m,
                        Response = response
                    });
                }
                transferLog.Count = transferLog.TransferLogDetails.Count;
                //保存日志
                await _transferLogRepository.InsertAsync(transferLog);
                esLogs.ToES<ESStudentLog>();
                return $"Student Trasfer info:Total:{models.Count} Success:{successCount} Fail:{models.Count - successCount}";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> SetClassProcessAsync(int productType, int branchId, List<CrmClassCourse> targetClasses, int classPerLevel)
        {
            var branch = await _branchRepository.FirstOrDefaultAsync(e => e.Bran_ID == branchId);
            var classRelations = await _classRelationRepository.GetListAsync();
            var models = new List<SetClassProcessModel>();
            foreach (var tc in targetClasses)
            {
                var mtsClassId = classRelations.FirstOrDefault(e => e.CrmClassId == tc.Clas_ID)?.MTSClassId;
                var remainHour = await GetRemainHourOfClassAsync(tc, classPerLevel);
                models.Add(new SetClassProcessModel()
                {
                    ClassId = mtsClassId,
                    LessonPeriod = remainHour
                });
            }

            var successCount = 0;
            DateTime now = DateTime.Now;
            string batchNo = $"{DataTransferConst.ProcessTransferNo}{now.ToString("yyyyMMddHHmmss")}";
            TransferLog transferLog = new TransferLog()
            {
                BatchNo = batchNo,
                BranchInfo = $"{branch.Bran_ID}-{branch.Bran_Name}-{branch.Bran_SapId}",
                ProductTypeInfo = $"{productType}",
                Type = TransferLogType.ClassProcess,
                CreateTime = DateTime.Now
            };
            foreach (var m in models)
            {
                var response = HttpHelper.PostAsync<CommonMTSResponseEntity>(_classOptions.Value.ClassProcessSetUrl, m);
                if (response.ResultCode == "000000")
                    successCount++;
                //保存日志
                transferLog.TransferLogDetails.Add(new TransferLogDetail()
                {
                    Para = JsonConvert.SerializeObject(m),
                    Response = JsonConvert.SerializeObject(response),
                    ClassInfo = $"{m.ClassId}-{m.LessonPeriod}"
                });
            }
            transferLog.Count = transferLog.TransferLogDetails.Count;
            //保存日志
            await _transferLogRepository.InsertAsync(transferLog);
            return $"ClassProcessSet Trasfer info:Total:{models.Count} Success:{successCount} Fail:{models.Count - successCount}";
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
                e => e.OriginalProductName.Replace(" ", "") == product.Prod_Name.Replace(" ", "")
                ))?.NewProductName;
            return await _productRepository.FirstOrDefaultAsync(e => e.Prod_Name.Replace(" ", "") == newName.Replace(" ", ""));
        }
        /// <summary>
        /// 获取班级的当前级别（逻辑正确）
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        private async Task<string> GetCurrentProductLevelOfClassAsync(CrmClassCourse cc, int ClassPerLevel)
        {
            var plCount = Convert.ToInt32(Math.Round((decimal)cc.Clas_ClassHour * 3 / ClassPerLevel));
            var plNames = await GetProductLevelsOfClassAsync(cc, plCount);
            var waitHour = cc.ClassSchedules.Count(e => e.Clsc_Status == 0 && e.Clsc_Deleted == 0);
            var fullHour = waitHour * 3;
            //超过总共的时间,直接从0开始
            if (fullHour >= plCount * ClassPerLevel)
            {
                return plNames[0];
            }
            var startIndex = 0;
            if (fullHour != 0 && fullHour % ClassPerLevel == 0)
            {
                startIndex = plCount - (fullHour / ClassPerLevel);
            }
            else
            {
                startIndex = plCount - Convert.ToInt32(Math.Ceiling((decimal)fullHour / ClassPerLevel));
            }
            return plNames[startIndex];
        }
        /// <summary>
        /// 获取班级剩余课时（逻辑正确）
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        private async Task<int> GetRemainHourOfClassAsync(CrmClassCourse cc, int ClassPerLevel)
        {
            var waitHour = cc.ClassSchedules.Count(e => e.Clsc_Status == 0 && e.Clsc_Deleted == 0);
            var plCount = Convert.ToInt32(Math.Round((decimal)cc.Clas_ClassHour * 3 / ClassPerLevel));
            var remainHour = 0;
            var fullHour = waitHour * 3;
            //当总课时超过或者是卡在等级上的时候
            if ((fullHour >= plCount * ClassPerLevel) || (fullHour != 0 && fullHour % ClassPerLevel == 0))
            {
                remainHour = ClassPerLevel;
            }
            else
            {
                remainHour = fullHour % ClassPerLevel;
            }
            return await Task.FromResult(remainHour);
        }
        /// <summary>
        /// 获取班级的所有级别
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        private async Task<List<string>> GetProductLevelsOfClassAsync(CrmClassCourse cc, int? plCount = null)
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
        /// 1】学生至少有一个级别
        /// 2】学生级别数量取最接近实际的
        /// </summary>
        /// <returns></returns>
        private async Task<List<string>> GetStudentProductLevelsOfClassAsync(CrmClassCourse cc, CrmClassStudent cs, int ClassPerLevel)
        {
            //学生剩余课时
            var studentWaitHour = (cs.Clst_ClassHour - cs.Clst_AdjustHour - cs.Clst_FinishHour) * 3;
            var remainHourOfClass = await GetRemainHourOfClassAsync(cc, ClassPerLevel);
            var currentPlName = await GetCurrentProductLevelOfClassAsync(cc, ClassPerLevel);
            var allPlNames = await GetProductLevelsOfClassAsync(cc);
            var startIndex = allPlNames.IndexOf(currentPlName);
            var plCount = 0;
            if (studentWaitHour <= remainHourOfClass)
            {
                plCount = 1;
            }
            else
            {
                plCount = Convert.ToInt32(Math.Round((decimal)(studentWaitHour - remainHourOfClass) / ClassPerLevel) + 1);
            }
            var plNames = allPlNames.Skip(startIndex).Take(plCount).ToList();
            if (plNames.Count == 0)
            {
                var a = 1;
            }
            return plNames;
        }
        #endregion
    }
}
