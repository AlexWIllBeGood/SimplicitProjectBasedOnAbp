using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransfer.Application;
using DataTransfer.Application.CrmServices;
using DataTransfer.Domain.Entities.Coupan;
using DataTransfer.Infrastructure.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace DataTransfer.HttpApi.Host.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ABCController : ControllerBase
    {
        private readonly CoupanService _coupanService;
        private readonly CourseService _classService;

        public ABCController(CoupanService coupanService,CourseService classService)
        {
            this._coupanService = coupanService;
            this._classService = classService;
        }
        [HttpPost]
        public FileContentResult ExportFile()
        {
            var fileContent = ExcelHelper.Export("TempSheet");
            return File(fileContent, ExcelHelper.ExcelContentType, "table.xlsx");
        }
        /// <summary>
        /// 处理方庄新概念产品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> HandleNewNCE_FZ()
        {
            var productTypeId = 3;
            var branchId = 101005000;
            var beginDate = Convert.ToDateTime("2000-11-01");
            var currentDate = Convert.ToDateTime("2020-11-01");
            var endDate = Convert.ToDateTime("2040-11-01");
            var defaultSA = "jennifer_jy";
            var defaultFT = "muham_mjm";
            var defaultLT = "doris_zq";
            var classStatus_Normal = "0,1";
            var classStatus_Stop = "4";

            //导入预售班级
            var result1 = await _classService.SendClassToMtsAsync(productTypeId, branchId, 1, currentDate, endDate, defaultSA, defaultFT, defaultLT);
            //导入已开班班级
            var result2 = await _classService.SendClassToMtsAsync(productTypeId, branchId, 2, beginDate,currentDate, defaultSA, defaultFT, defaultLT);
            //导入预售班学生
            var result3 = await _classService.SendStudentToMtsAsync(productTypeId, branchId, 1, currentDate, endDate, classStatus_Normal);
            //导入已开班学生（入班）
            var result4 = await _classService.SendStudentToMtsAsync(productTypeId, branchId, 2, beginDate, currentDate, classStatus_Normal, true);
            //导入已开班学生（不入班）
            var result5 = await _classService.SendStudentToMtsAsync(productTypeId, branchId, 2, beginDate, currentDate, classStatus_Stop, false);
            //设置班级进度
            var result6 = await _classService.SetClassProcessAsync(productTypeId, branchId, 2, beginDate, currentDate);

            return $"PreClass:{result1}/r/nPostClass:{result2}/r/nPreStudent:{result3}/r/nPostClassIn:{result4}/r/nPostClassOut:{result5}/r/nSetClass:{result6}/r/n";
        }
        /// <summary>
        /// FZ_NCE_PRE
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> SendClassToMtsAsync_FZ_NCE_PRE()
        {
            return await _classService.SendClassToMtsAsync(3, 101005000, 1, Convert.ToDateTime("2020-11-01"), Convert.ToDateTime("2040-11-01"), "jennifer_jy", "muham_mjm", "doris_zq");
        }
        /// <summary>
        /// FZ_NCE_PRO
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> SendClassToMtsAsync_FZ_NCE_PRO()
        {
            var classInfo= await _classService.SendClassToMtsAsync(3, 101005000, 2, Convert.ToDateTime("2000-11-01"), Convert.ToDateTime("2020-11-01"), "jennifer_jy", "muham_mjm", "doris_zq");
            return $"{classInfo}";
        }

        /// <summary>
        /// FZ_NCE_PRE
        /// </summary>
        [HttpPost]
        public async Task<string> SendStudentToMtsAsync_FZ_NCE_PRE()
        {
            return await _classService.SendStudentToMtsAsync(3, 101005000, 1, Convert.ToDateTime("2020-11-01"), Convert.ToDateTime("2040-11-01"), "0,1");
        }

        /// <summary>
        /// FZ_NCE_PRO
        /// </summary>
        [HttpPost]
        public async Task<string> SendStudentToMtsAsync_FZ_NCE_PRO_IN_CLASS()
        {
            return await _classService.SendStudentToMtsAsync(3, 101005000, 2, Convert.ToDateTime("2000-11-01"), Convert.ToDateTime("2020-11-01"), "0,1", true);

        }
        /// <summary>
        /// FZ_NCE_PRO
        /// </summary>
        [HttpPost]
        public async Task<string> SendStudentToMtsAsync_FZ_NCE_PRO_OUT_CLASS()
        {
            return await _classService.SendStudentToMtsAsync(3, 101005000, 2, Convert.ToDateTime("2000-11-01"), Convert.ToDateTime("2020-11-01"), "4", false);

        }

        /// <summary>
        /// FZ_NCE_PRO
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> SetClassProcessAsync_FZ_NCE_PRO()
        {
            var classSetInfo = await _classService.SetClassProcessAsync(3, 101005000, 2, Convert.ToDateTime("2000-11-01"), Convert.ToDateTime("2020-11-01"));
            return $"{classSetInfo}";
        }

        #region 添加老师信息
        /// <summary>
        /// 查找老师班级ID
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> FindTeacherClassAsync()
        {
            return await _classService.FindTeacherClassAsync();
        }
        /// <summary>
        /// 添加中教师信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> AddTeacherNameAsync()
        {
            return await _classService.AddTeacherNameAsync();
        }
        /// <summary>
        /// 检测范围班级的课次数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<int?>> DetectClassHourAsync_FZ_NCE_PRE()
        {
            return await _classService.DetectClassHourAsync(3, 101005000, 1, Convert.ToDateTime("2020-11-01"), Convert.ToDateTime("2040-11-01"));
        }
        /// <summary>
        /// 检测范围班级的课次数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<int?>> DetectClassHourAsync_FZ_NCE_PRO()
        {
            return await _classService.DetectClassHourAsync(3, 101005000, 2, Convert.ToDateTime("2000-11-01"), Convert.ToDateTime("2020-11-01"));
        }
        #endregion

    }
}
