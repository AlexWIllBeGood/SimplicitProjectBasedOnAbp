using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransfer.Application.Contracts.IApplicationServices;
using DataTransfer.Domain.IRepositories.ICrmRepositories;
using DataTransfer.Infrastructure.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using static DataTransfer.Infrastructure.Utils.ExcelHelper;

namespace DataTransfer.HttpApi.Host.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportApplicationService _reportApplicationService;
        private readonly IBranchRepository _branchRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        public ReportController(IReportApplicationService reportApplicationService, IBranchRepository branchRepository, IProductTypeRepository productTypeRepository)
        {
            this._reportApplicationService = reportApplicationService;
            this._branchRepository = branchRepository;
            this._productTypeRepository = productTypeRepository;
        }
        /// <summary>
        /// 导出学生老师信息
        /// </summary>
        /// <param name="productTypeName">产品中文名称</param>
        /// <param name="branchName">中心中文名称</param>
        /// <param name="currentDate">日期</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<FileContentResult> ExportStudentAndClassInfo(string productTypeName, string branchName, DateTime currentDate)
        {
            var productType = await _productTypeRepository.FirstOrDefaultAsync(e => e.Prot_Name.Contains(productTypeName));
            var branch = await _branchRepository.FirstOrDefaultAsync(e => e.Bran_Name.Contains(branchName));

            if (productType == null)
            {
                throw new UserFriendlyException("找不到该产品大类");
            }

            if (productType == null)
            {
                throw new UserFriendlyException("找不到该中心");
            }

            var productTypeId = productType.Prot_ID;
            var branchId = branch.Bran_ID;
            var beginDate = Convert.ToDateTime("2000-01-01");
            var endDate = Convert.ToDateTime("2100-01-01");

            var classStatus_Normal = "0,1";
            var classStatus_Stop = "4";

            var classPre = await _reportApplicationService.GetClassRange(productTypeId, branchId, 1, currentDate, endDate);
            var classPro = await _reportApplicationService.GetClassRange(productTypeId, branchId, 2, beginDate, currentDate);
            var studentPre = await _reportApplicationService.GetStudentRange(productTypeId, branchId, 1, currentDate, endDate, classStatus_Normal);
            var studentPro_InClass = await _reportApplicationService.GetStudentRange(productTypeId, branchId, 2, beginDate, currentDate, classStatus_Normal);
            var studentPro_OutClass = await _reportApplicationService.GetStudentRange(productTypeId, branchId, 2, beginDate, currentDate, classStatus_Stop);

            var fileContent = ExcelHelper.Export(
                new List<ExportParam> {
                    new ExportParam() {
                        SheetName="预售班",
                        ColumnEnNames=new List<string>(){  "Clas_Code","Clas_Name", "Prod_Name",},
                        ColumnCnNames=new List<string>(){ "班级编号","班级名称", "产品名称", },
                        Data=classPre
                },
                    new ExportParam() {
                        SheetName="在读班",
                        ColumnEnNames=new List<string>(){ "Clas_Code","Clas_Name", "Prod_Name"},
                        ColumnCnNames=new List<string>(){ "班级编号","班级名称", "产品名称" },
                        Data=classPro
                },
                    new ExportParam() {
                        SheetName="预售班学生",
                        ColumnEnNames=new List<string>(){ "Lead_Name", "Clas_Code", "Prod_Name"},
                        ColumnCnNames=new List<string>(){ "学生名称", "班级编号", "产品名称"},
                        Data=studentPre
                },
                    new ExportParam() {
                        SheetName="在读班学生（MTS需入班）",
                        ColumnEnNames=new List<string>(){ "Lead_Name", "Clas_Code", "Prod_Name"},
                        ColumnCnNames=new List<string>(){ "学生名称", "班级编号", "产品名称"},
                        Data=studentPro_InClass
                },
                    new ExportParam() {
                        SheetName="在读班学生（MTS不需入班）",
                        ColumnEnNames=new List<string>(){ "Lead_Name", "Clas_Code", "Prod_Name"},
                        ColumnCnNames=new List<string>(){ "学生名称", "班级编号", "产品名称"},
                        Data=studentPro_OutClass
                }
                }
                );
            return File(fileContent, ExcelHelper.ExcelContentType, $"Student&Classes({branch.Bran_Name}_{productType.Prot_Name}).xlsx");
        }

        [HttpPost]
        public async Task TestEs()
        {
            List<string> temp = new List<string>() { "s1", "s2", "s3", "s4" };
            temp.ToES<string>("");
        }
    }
}
