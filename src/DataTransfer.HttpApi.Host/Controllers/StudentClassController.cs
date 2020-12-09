using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransfer.Application;
using DataTransfer.Application.Contracts.IApplicationServices;
using DataTransfer.Application.CrmServices;
using DataTransfer.Domain.Entities.Coupan;
using DataTransfer.Domain.Entities.CrmEntities;
using DataTransfer.Domain.Entities.Temp;
using DataTransfer.Domain.IRepositories.ICrmRepositories;
using DataTransfer.Domain.IServices;
using DataTransfer.Infrastructure.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace DataTransfer.HttpApi.Host.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentClassController : ControllerBase
    {
        //private readonly CoupanService _coupanService;
        //private readonly ICourseService _courseService;
        private readonly IClassDomainService _classDomainService;
        private readonly IReportApplicationService _reportApplicationService;
        private readonly IClassStudentApplicationService _classStudentApplicationService;

        public StudentClassController(
            //CoupanService coupanService, 
            //CourseService courseService, 
            IClassDomainService classDomainService,
            IReportApplicationService reportApplicationService,
            IClassStudentApplicationService classStudentApplicationService)
        {
            //this._coupanService = coupanService;
            //this._courseService = courseService;
            this._classDomainService = classDomainService;
            this._reportApplicationService = reportApplicationService;
            this._classStudentApplicationService = classStudentApplicationService;
        }

        /// <summary>
        /// 处理方庄新概念产品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> Handle()
        {
            //方庄新概念
            //var productTypeId = 3;
            //var branchId = 101005000;
            //var classPerLevel= 42;
            //var defaultSA = "jennifer_jy";
            //var defaultFT = "muham_mjm";
            //var defaultLT = "doris_zq";
            //var currentDate = Convert.ToDateTime("2020-11-01");

            //方庄进阶
            var productTypeId = 2;
            var branchId = 101005000;
            var classPerLevel = 48;
            var defaultSA = "jennifer_jy";
            var defaultFT = "muham_mjm";
            var defaultLT = "doris_zq"; //基本开班的班级都存在中教信息
            var currentDate = Convert.ToDateTime("2020-12-04");


            var beginDate = Convert.ToDateTime("2000-01-01");
            var endDate = Convert.ToDateTime("2100-01-01");
            var classStudentStatus_Normal = "0,1";
            var classStudentStatus_Stop = "4";
            var classStatus_pre = 1;
            var classStatus_pro = 2;

            //预售班范围
            var preClasses = await _classDomainService.GetClassCourseRange(productTypeId, branchId, classStatus_pre, currentDate, endDate);
            ////在读班范围
            var proClasses = await _classDomainService.GetClassCourseRange(productTypeId, branchId, classStatus_pro, beginDate, currentDate);
            ////导入预售班级
            var result1 = await _classStudentApplicationService.SendClassToMtsAsync(productTypeId, branchId, preClasses, classPerLevel, defaultSA, defaultFT, defaultLT);
            //导入已开班班级
            var result2 = await _classStudentApplicationService.SendClassToMtsAsync(productTypeId, branchId, proClasses, classPerLevel, defaultSA, defaultFT, defaultLT);
            ////导入预售班学生
            var result3 = await _classStudentApplicationService.SendStudentToMtsAsync(productTypeId, branchId, preClasses, classPerLevel, classStatus_pre, classStudentStatus_Normal);
            ////导入已开班学生（入班）
            var result4 = await _classStudentApplicationService.SendStudentToMtsAsync(productTypeId, branchId, proClasses, classPerLevel, classStatus_pro, classStudentStatus_Normal, true);
            ////导入已开班学生（不入班）
            var result5 = await _classStudentApplicationService.SendStudentToMtsAsync(productTypeId, branchId, proClasses, classPerLevel, classStatus_pro, classStudentStatus_Stop, false);
            ////设置班级进度
            var result6 = await _classStudentApplicationService.SetClassProcessAsync(productTypeId, branchId, proClasses, classPerLevel);

            return $"PreClass:{result1}\r\nPostClass:{result2}\r\nPreStudent:{result3}\r\nPostClassIn:{result4}\r\nPostClassOut:{result5}\r\nSetClass:{result6}\r\n";
        }

        /// <summary>
        /// FZ_NCE_PRE
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //public async Task<string> SendClassToMtsAsync_FZ_NCE_PRE()
        //{
        //    return await _classService.SendClassToMtsAsync(3, 101005000, 1, Convert.ToDateTime("2020-11-01"), Convert.ToDateTime("2040-11-01"), "jennifer_jy", "muham_mjm", "doris_zq");
        //}
        ///// <summary>
        ///// FZ_NCE_PRO
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<string> SendClassToMtsAsync_FZ_NCE_PRO()
        //{
        //    var classInfo = await _classService.SendClassToMtsAsync(3, 101005000, 2, Convert.ToDateTime("2000-11-01"), Convert.ToDateTime("2020-11-01"), "jennifer_jy", "muham_mjm", "doris_zq");
        //    return $"{classInfo}";
        //}

        ///// <summary>
        ///// FZ_NCE_PRE
        ///// </summary>
        //[HttpPost]
        //public async Task<string> SendStudentToMtsAsync_FZ_NCE_PRE()
        //{
        //    return await _classService.SendStudentToMtsAsync(3, 101005000, 1, Convert.ToDateTime("2020-11-01"), Convert.ToDateTime("2040-11-01"), "0,1");
        //}

        ///// <summary>
        ///// FZ_NCE_PRO
        ///// </summary>
        //[HttpPost]
        //public async Task<string> SendStudentToMtsAsync_FZ_NCE_PRO_IN_CLASS()
        //{
        //    return await _classService.SendStudentToMtsAsync(3, 101005000, 2, Convert.ToDateTime("2000-11-01"), Convert.ToDateTime("2020-11-01"), "0,1", true);

        //}
        ///// <summary>
        ///// FZ_NCE_PRO
        ///// </summary>
        //[HttpPost]
        //public async Task<string> SendStudentToMtsAsync_FZ_NCE_PRO_OUT_CLASS()
        //{
        //    return await _classService.SendStudentToMtsAsync(3, 101005000, 2, Convert.ToDateTime("2000-11-01"), Convert.ToDateTime("2020-11-01"), "4", false);

        //}

        ///// <summary>
        ///// FZ_NCE_PRO
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<string> SetClassProcessAsync_FZ_NCE_PRO()
        //{
        //    var classSetInfo = await _classService.SetClassProcessAsync(3, 101005000, 2, Convert.ToDateTime("2000-11-01"), Convert.ToDateTime("2020-11-01"));
        //    return $"{classSetInfo}";
        //}

        //#region 添加老师信息
        ///// <summary>
        ///// 查找老师班级ID
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<string> FindTeacherClassAsync()
        //{
        //    return await _classService.FindTeacherClassAsync();
        //}
        ///// <summary>
        ///// 添加中教师信息
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<string> AddTeacherNameAsync()
        //{
        //    return await _classService.AddTeacherNameAsync();
        //}
        ///// <summary>
        ///// 检测范围班级的课次数
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<List<int?>> DetectClassHourAsync_FZ_NCE_PRE()
        //{
        //    return await _classService.DetectClassHourAsync(3, 101005000, 1, Convert.ToDateTime("2020-11-01"), Convert.ToDateTime("2040-11-01"));
        //}
        ///// <summary>
        ///// 检测范围班级的课次数
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<List<int?>> DetectClassHourAsync_FZ_NCE_PRO()
        //{
        //    return await _classService.DetectClassHourAsync(3, 101005000, 2, Convert.ToDateTime("2000-11-01"), Convert.ToDateTime("2020-11-01"));
        //}
        //#endregion

    }
}
