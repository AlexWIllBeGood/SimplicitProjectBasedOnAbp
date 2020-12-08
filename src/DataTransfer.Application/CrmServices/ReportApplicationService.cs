using DataTransfer.Application.Contracts.IApplicationServices;
using DataTransfer.Domain.Entities.CrmEntities;
using DataTransfer.Domain.IRepositories.ICrmRepositories;
using DataTransfer.Domain.IServices;
using DataTransfer.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTransfer.Application.CrmServices
{
    public class ReportApplicationService : BaseApplicationService, IReportApplicationService
    {
        private readonly IClassCourseRepository _classCourseRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IClassDomainService _classDomainService;
        public ReportApplicationService(
            IClassCourseRepository classCourseRepository, 
            IBranchRepository branchRepository, 
            IContractRepository contractRepository,
            IClassDomainService classDomainService)
        {
            this._classCourseRepository = classCourseRepository;
            this._branchRepository = branchRepository;
            this._contractRepository = contractRepository;
            this._classDomainService = classDomainService;
        }
        public async Task TestBranch()
        {
            var temp = await _branchRepository.FirstOrDefaultAsync();
        }
        /// <summary>
        /// 获取班级筛选范围
        /// </summary>
        /// <param name="productType"></param>
        /// <param name="branchId"></param>
        /// <param name="clasStatus"></param>
        /// <param name="beginTimeDate"></param>
        /// <param name="endTimeDate"></param>
        /// <returns></returns>
        public async Task<dynamic> GetClassRange(int productType, int branchId, int clasStatus, DateTime? beginTimeDate, DateTime? endTimeDate)
        {
            var targetClasses = await _classDomainService.GetClassCourseRange(productType, branchId, clasStatus, beginTimeDate, endTimeDate);
            return targetClasses.Select(e => new { e.Clas_Name, e.Product.Prod_Name, e.Clas_Code, LT = e.LT?.User_Logon, FT = e.FT?.User_Logon, SA = e.SA?.User_Logon }).ToList();
        }
        /// <summary>
        /// 获取学生筛选范围
        /// </summary>
        /// <param name="productType"></param>
        /// <param name="branchId"></param>
        /// <param name="clasStatus"></param>
        /// <param name="beginTimeDate"></param>
        /// <param name="endTimeDate"></param>
        /// <param name="classStatus"></param>
        /// <returns></returns>
        public async Task<dynamic> GetStudentRange(int productType, int branchId, int clasStatus, DateTime? beginTimeDate, DateTime? endTimeDate, string classStatus)
        {
            var branch = await _branchRepository.FirstOrDefaultAsync(e => e.Bran_ID == branchId);
            var targetClasses = await _classDomainService.GetClassCourseRange(productType, branchId, clasStatus, beginTimeDate, endTimeDate);
            var classIds = targetClasses.Select(e => e.Clas_ID).ToList();
            List<CrmClassStudent> classStudents;
            if (string.IsNullOrEmpty(classStatus))
            {
                classStudents = targetClasses.SelectMany(e => e.ClassStudents).ToList();
            }
            else
            {
                List<int> classStatusList = classStatus.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray().Select<string, int>(e => Convert.ToInt32(e)).ToList();
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

            List<object> models = new List<object>();
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

                var contract = contracts.FirstOrDefault();
                var lead = contract.Lead;
                var classCourse = contract.ClassCourse;
                var product = contract.Product;

                models.Add(new { lead.Lead_Name, classCourse.Clas_Code, product.Prod_Name });
            }

            return models;
        }
    }
}
