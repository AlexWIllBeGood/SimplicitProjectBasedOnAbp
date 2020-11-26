using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransfer.Application;
using DataTransfer.Application.CrmServices;
using DataTransfer.Domain.Entities.Coupan;
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
