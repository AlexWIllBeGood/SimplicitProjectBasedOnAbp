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
            return await _classService.SendClassToMtsAsync(3, 101005000, 1, Convert.ToDateTime("2020-11-01"), null, "jennifer_jy", "muham_mjm", "doris_zq");
        }
        /// <summary>
        /// FZ_NCE_PRO
        /// </summary>
        /// <returns></returns>
        public async Task<string> SendClassToMtsAsync_FZ_NCE_Pro()
        {
            var classInfo= await _classService.SendClassToMtsAsync(3, 101005000, 2, null, Convert.ToDateTime("2020-11-01"), "jennifer_jy", "muham_mjm", "doris_zq");
            var classSetInfo = await _classService.SetClassProcessAsync(3, 101005000, 2, null, Convert.ToDateTime("2020-11-01"));
            return $"{classInfo}/r/n{classSetInfo}";
        }

        /// <summary>
        /// 发送学生信息到MTS
        /// </summary>
        [HttpPost]
        public async Task<string> SendStudentToMtsAsync()
        {
            return await _classService.SendStudentToMtsAsync(3, 101005000, 1, Convert.ToDateTime("2020-11-01"));
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
        #endregion

    }
}
