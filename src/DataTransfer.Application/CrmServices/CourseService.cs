using DataTransfer.Application.Contracts.Dtos.InputDtos;
using DataTransfer.Domain.Entities.CrmEntities;
using DataTransfer.Domain.Entities.LocalEntities;
using DataTransfer.Domain.Entities.Temp;
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
        private readonly IOptionsMonitor<CRMOptions> _classOptions;
        private readonly ClassCourseRepository _classCourseRepository;
        private readonly ProductLevelRepository _productLevelRepository;
        private readonly LeadRepository _leadRepository;
        private readonly ProductRepository _productRepository;
        private readonly ProductRelationRepository _productRelationRepository;
        private readonly ContractRepository _contractRepository;
        private readonly ClassRelationRepository _classRelationRepository;
        public CourseService(
            IOptionsMonitor<CRMOptions> classOptions,
            ClassCourseRepository classCourseRepository,
            ProductLevelRepository productLevelRepository,
            LeadRepository leadRepository,
            ContractRepository contractRepository,
            ProductRepository productRepository,
            ProductRelationRepository productRelationRepository,
            ClassRelationRepository classRelationRepository
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
        }

        /// <summary>
        /// 发送班级数据到MTS
        /// </summary>
        /// <returns></returns>
        public async Task<string> SendClassToMtsAsync()
        {
            var Nov = Convert.ToDateTime("2020-11-01");
            var targetClasses = await _classCourseRepository
                .Include(e => e.Product)
                .Include(e => e.Branch)
                .Include(e => e.SA)
                .Include(e => e.LT)
                .Include(e => e.FT)
                .Include(e => e.ClassStudents)
                .Where(e =>
                e.Product.Prod_Type == 3
                && e.Clas_BranID == 101005000
                && e.Clas_Status == 1
                && e.Clas_Deleted == 0
                && e.Clas_ActualBeginDate > Nov
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
                model.ProductLevelId = GetProductLevelNameByClassCode(tc.Clas_Code) ?? "";
                model.ClassCName = tc.Clas_Code;
                //model.SAId = tc.SA?.User_Logon ?? "jennifer_jy";
                model.SAId = "jennifer_jy";
                model.HasFT = true;
                model.FTId = "muham_mjm";
                model.HasLT = true;
                model.LTId = "doris_zq";
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

            foreach (var c in clsses)
            {
                var response = HttpHelper.PostAsync<ClassMRTSResponseEntity>(_classOptions.CurrentValue.ClassSendMTSUrl, c);
                if (response.ResultCode == "000000"
                    || response.ResultData == "100002")
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
            }
            return $"Class Trasfer info:Total:{clsses.Count} Success:{successCount} Fail:{clsses.Count - successCount}";
        }
        /// <summary>
        /// 发送学生合同信息到MTS
        /// </summary>
        /// <returns></returns>
        public async Task<string> SendStudentToMtsAsync()
        {
            try
            {
                var Nov = Convert.ToDateTime("2020-11-01");
                var targetClasses = await _classCourseRepository
                    .Where(e =>
                    e.Product.Prod_Type == 3
                    && e.Clas_BranID == 101005000
                    && e.Clas_Status == 1
                    && e.Clas_Deleted == 0
                    && e.Clas_ActualBeginDate > Nov
                    ).ToListAsync();

                var classIds = targetClasses.Select(e => e.Clas_ID).ToList();
                //查找所有相关的合同
                var allContracts = _contractRepository
                    .Include(e => e.ClassCourse)
                    .Include(e => e.Product)
                    .Include(e => e.Lead)
                    .ThenInclude(e=>e.Branch)
                    .Include(e => e.Order)
                    .ThenInclude(e => e.CC)
                    .Where(e => classIds.Contains((int)e.Cont_ClassId)
                    && e.Cont_Status == 2
                    && e.Cont_LeadId != null
                    && e.Cont_ProductID != null
                    && e.Cont_OrderID != null
                    )
                    .ToList();
                //根据合同获取所有相关的班级对应信息
                var allCrmClassIds = allContracts.Select(e => e.Cont_ClassId).Distinct();
                var allClassRelations = _classRelationRepository
                    .Where(e => allCrmClassIds.Contains(e.CrmClassId))
                    .ToList();
                //将相关合同按照签约人，产品，订单划分
                var contractGroups = allContracts
                    .GroupBy(e => new { e.Cont_LeadId, e.Cont_ProductID, e.Cont_OrderID })
                    .Select(e => new
                    {
                        e.Key.Cont_LeadId,
                        e.Key.Cont_ProductID,
                        e.Key.Cont_OrderID,
                        Count = e.Count()
                    })
                    .ToList();

                List<CrmStudentInfoModel> models = new List<CrmStudentInfoModel>();
                foreach (var cg in contractGroups)
                {
                    var contracts = allContracts
                        .Where(e => e.Cont_LeadId == cg.Cont_LeadId
                        && e.Cont_ProductID == cg.Cont_ProductID
                        && e.Cont_OrderID == cg.Cont_OrderID)
                        .OrderBy(e => e.Cont_CreatedDate)
                        .ToList();

                    var contract = contracts.FirstOrDefault();
                    var order = contract.Order;
                    var lead = contract.Lead;
                    var classCourse = contract.ClassCourse;
                    var cc = order.CC;
                    var branch = lead.Branch;
                    var product = await GetNewProductByOriginProductAsync(contract.Product);
                    var productLevels = await GetNewProductLevelsAsync(contracts, classCourse.Clas_Code, product.Prod_Levels);
                    var beginLevel = productLevels[0];
                    var endLevel = productLevels[productLevels.Count - 1];
                    //合同开始时间为当前时间，结束时间根据等级数量去进行估算
                    DateTime contractBeginTime = DateTime.Now;
                    DateTime contractEndTime = DateTime.Now.AddMonths((int)6 * productLevels.Count());

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
                    model.contBeginDate = contract?.Cont_BegDate ?? contractBeginTime;
                    model.contEndDate = contract?.Cont_EndDate ?? contractEndTime;
                    model.contStatus = "02"; //02 执行、03冻结、06结束、01结束
                    model.productId = product?.Prod_ID;
                    model.productType = product.Prod_Type;
                    model.beginProductLevelId = beginLevel;
                    model.endProductLevelId = endLevel;
                    model.currentLevel = beginLevel;
                    model.productLevelId = string.Join(",", productLevels);
                    model.contractShift = "Contract";
                    model.Cont_ParentId = null;
                    model.Cont_ShiftType = "Contract";
                    model.Cont_reason = null;
                    model.Cont_RefundAmount = 0;
                    model.ccUserName = cc?.User_Logon;
                    model.classId = allClassRelations.FirstOrDefault(e => e.CrmClassId == contract.Cont_ClassId)?.MTSClassId;
                    model.levelCodes = beginLevel;
                    model.currLevelCodes = beginLevel;
                    model.contractTypeSub = product.Prod_SubTypeID;
                    models.Add(model);
                }
                var successCount = 0;
                foreach (var m in models)
                {
                    var response = HttpHelper.PostAsync<CommonMTSResponseEntity>(_classOptions.CurrentValue.OrderSendMTSUrl, m);
                    if (response.ResultCode == "000000")
                        successCount++;
                }

                return $"Class Trasfer info:Total:{models.Count} Success:{successCount} Fail:{models.Count - successCount}";

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [Obsolete]
        public async Task<string> SendStudentToMtsAsyncOld()
        {
            try
            {
                var Nov = Convert.ToDateTime("2020-11-01");
                var targetClasses = await _classCourseRepository
                    .Include(e => e.Product)
                    .Include(e => e.Branch)
                    .Include(e => e.ClassStudents)
                    .Where(e =>
                    e.Product.Prod_Type == 3
                    && e.Clas_BranID == 101005000
                    && e.Clas_Status == 1
                    && e.Clas_Deleted == 0
                    && e.Clas_ActualBeginDate > Nov
                    ).ToListAsync();
                var classStudents = targetClasses.SelectMany(e => e.ClassStudents).ToList();
                var leadIds = classStudents.Select(e => e.Clst_LeadID).Distinct().ToList();

                var leads = await _leadRepository
                    .Include(e => e.Branch)
                    .Include(e => e.Orders)
                    .Include(e => e.Contracts)
                    .ThenInclude(e => e.Product)
                    .Where(e => leadIds.Contains(e.Lead_LeadID))
                    .ToListAsync();

                List<CrmStudentInfoModel> models = new List<CrmStudentInfoModel>();
                foreach (var lead in leads)
                {
                    //区分不同的产品
                    var products = lead.Contracts.Select(e => e.Product).Distinct().ToList();
                    foreach (var product in products)
                    {
                        var contract = lead.Contracts.Where(e => e.Cont_ProductID == product.Prod_ID).OrderBy(e => e.Cont_CreatedDate).FirstOrDefault();
                        var order = contract.Order;
                        var cc = order.CC;
                        var branch = lead.Branch;
                        var productLevelIds = contract.Cont_ProductLevels.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().Select<string, int>(e => int.Parse(e));
                        var productLevels = _productLevelRepository.Where(e => productLevelIds.Contains(e.Prol_ID)).Select(e => e.Prol_Name).OrderBy(e => e).ToList();
                        var beginLevel = productLevels[0];
                        var endLevel = productLevels[productLevels.Count - 1];
                        //合同开始时间为当前时间，结束时间根据等级数量去进行估算
                        DateTime contractBeginTime = DateTime.Now;
                        DateTime contractEndTime = DateTime.Now.AddMonths((int)6 * productLevelIds.Count());

                        CrmStudentInfoModel model = new CrmStudentInfoModel();
                        model.platfromKey = _classOptions.CurrentValue.MTSPlatformKey;
                        model.userName = lead?.Lead_LeadID.ToString();
                        model.email = lead?.Lead_Email;
                        model.cName = lead?.Lead_Name;
                        model.eName = lead?.Lead_EnName;
                        model.gender = lead?.Lead_Gender == 0 ? 1 : 0;
                        model.birthday = lead?.Lead_Birthday;
                        model.mobile = lead?.Lead_Mobile;
                        model.branchId = lead.Branch?.Bran_SapId;
                        model.ccUserId = cc.User_Logon;
                        model.contractId = contract?.Cont_ContractID;
                        model.emeId = lead?.Lead_LeadID;
                        model.contractNum = contract?.Cont_Number;
                        model.cont_isbinding = null;
                        model.contractType = product.Prod_Type.ToString();
                        model.contractBranchId = branch?.Bran_SapId.ToString();
                        model.contBeginDate = contract?.Cont_BegDate ?? contractBeginTime;
                        model.contEndDate = contract?.Cont_EndDate ?? contractEndTime;
                        model.contStatus = "02"; //02 执行、03冻结、06结束、01结束
                        model.productId = product?.Prod_ID;
                        model.productType = product.Prod_Type;
                        model.beginProductLevelId = beginLevel;
                        model.endProductLevelId = endLevel;
                        model.currentLevel = beginLevel;
                        model.productLevelId = string.Join(",", productLevels);
                        model.contractShift = "Contract";
                        model.Cont_ParentId = null;
                        model.Cont_ShiftType = "Contract";
                        model.Cont_reason = null;
                        model.Cont_RefundAmount = 0;
                        model.ccUserName = cc.User_Logon;
                        model.classId = contract.Cont_ClassId;
                        model.levelCodes = beginLevel;
                        model.currLevelCodes = beginLevel;
                        model.contractTypeSub = product.Prod_SubTypeID;
                        models.Add(model);
                    }
                }
                var successCount = 0;
                foreach (var m in models)
                {
                    var response = HttpHelper.PostAsync<CommonMTSResponseEntity>(_classOptions.CurrentValue.OrderSendMTSUrl, m);
                    if (response.ResultCode == "000000")
                        successCount++;
                }

                return $"Class Trasfer info:Total:{models.Count} Success:{successCount} Fail:{models.Count - successCount}";
            }
            catch (Exception ex)
            {

                return "error";
            }
        }
        /// <summary>
        /// 和当前业务相关，不可重用
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private string GetProductLevelNameByClassCode(string code)
        {
            var a = code.Replace("FZ-LNCE", "").Substring(0, 1);
            return a == "1" ? "NEW_NCE1" : "NEW_NCE4";
        }
        private async Task<CrmProduct> GetNewProductByOriginProductAsync(CrmProduct product)
        {
            var newName = (await _productRelationRepository.FirstOrDefaultAsync(
                e => e.OriginalProductName == product.Prod_Name.Replace(" ", "")
                ))?.NewProductName;

            return await _productRepository.FirstOrDefaultAsync(e => e.Prod_Name == newName);
        }
        /// <summary>
        /// 和当前业务相关，不可重用
        /// </summary>
        /// <param name="contracts"></param>
        /// <param name="classCode"></param>
        /// <param name="productLevelIds"></param>
        /// <returns></returns>
        private async Task<List<string>> GetNewProductLevelsAsync(List<CrmContract> contracts, string classCode, string productLevelIds)
        {
            var classHour = contracts.Sum(e => e.Cont_ClassHour) * 3;
            var plCount = (int)Math.Floor((decimal)classHour / 42) == 0 ? 1 : (int)Math.Floor((decimal)classHour / 42);
            string plName = GetProductLevelNameByClassCode(classCode);
            var startLevel = await _productLevelRepository.FirstOrDefaultAsync(e => e.Prol_Name == plName);
            var plIds = productLevelIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().Select<string, int>(e => int.Parse(e));
            var plNames = _productLevelRepository.Where(e => plIds.Contains(e.Prol_ID)).Select(e => e.Prol_Name).OrderBy(e => e).ToList();
            var startIndex = plNames.IndexOf(plName);
            return plNames.Skip(startIndex).Take(plCount).ToList();
        }
    }
}
