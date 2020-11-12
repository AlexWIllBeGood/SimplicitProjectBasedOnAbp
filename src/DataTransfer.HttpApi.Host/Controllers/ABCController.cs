using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransfer.Application;
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

        public ABCController(CoupanService coupanService)
        {
            this._coupanService = coupanService;
        }

        [HttpGet]
        public async Task<string> AddCoupan()
        {
            return await _coupanService.AddCoupanAsync();
        }
    }
}
