using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransfer.Application;
using DataTransfer.Application.Contracts.IApplicationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataTransfer.HttpApi.Host.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CoupanController : ControllerBase
    {
        private readonly ICoupanApplicationService _coupanApplicationService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coupanApplicationService"></param>
        public CoupanController(ICoupanApplicationService coupanApplicationService)
        {
            this._coupanApplicationService = coupanApplicationService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> ChangeCoupanProducts()
        {
            return await _coupanApplicationService.ChangeCoupanProductAsync();
        }
    }
}
