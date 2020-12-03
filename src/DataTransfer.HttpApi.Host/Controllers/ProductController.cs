using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransfer.Application.Contracts.IApplicationServices;
using DataTransfer.Domain.Entities.Temp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataTransfer.HttpApi.Host.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplicationService _productApplicationService;
        public ProductController(IProductApplicationService productApplicationService)
        {
            this._productApplicationService = productApplicationService;
        }

        /// <summary>
        /// 配置产品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> ConfigureProduct()
        {
            return await this._productApplicationService.ConfigureProduct("New_J", "进阶英语New", new List<ProductOption>() {
                new ProductOption(){ Clas_PeriodType="全周",Clas_ScaleType="大班",Clas_TeacherType="全中"},
                new ProductOption(){ Clas_PeriodType="全周",Clas_ScaleType="小班",Clas_TeacherType="全中"},
                new ProductOption(){ Clas_PeriodType="周末",Clas_ScaleType="小班",Clas_TeacherType="中外"},
                new ProductOption(){ Clas_PeriodType="周中",Clas_ScaleType="小班",Clas_TeacherType="中外"},
                new ProductOption(){ Clas_PeriodType="周末",Clas_ScaleType="中班",Clas_TeacherType="中外"},
                new ProductOption(){ Clas_PeriodType="周中",Clas_ScaleType="中班",Clas_TeacherType="中外"},
            }, "New_J", "New_J", 8, "New_J", "进阶 1-8 册", 11);
        }
    }
}
