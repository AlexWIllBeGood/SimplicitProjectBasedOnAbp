using DataTransfer.Application.Contracts.IApplicationServices;
using DataTransfer.Domain.Entities.Temp;
using DataTransfer.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.Application.CrmServices
{
    public class ProductApplicationService :BaseApplicationService, IProductApplicationService
    {
        private readonly IProductDomainService _productDomainService;
        public ProductApplicationService(IProductDomainService productDomainService)
        {
            this._productDomainService = productDomainService;
        }

        /// <summary>
        /// 配置产品
        /// </summary>
        /// <param name="productTypeCode"></param>
        /// <param name="productTypeName"></param>
        /// <param name="productLevelName"></param>
        /// <param name="productLevelCount"></param>
        /// <param name="productOptions"></param>
        /// <returns></returns>
        public async Task<string> ConfigureProduct(
            string productTypeCode, string productTypeName, List<ProductOption> productOptions,
            string productLevelCode,string productLevelName, int productLevelCount,
            string productShortName,string productName,int periodClassHour)
        {
            try
            {
                int productTypeId = await _productDomainService.ConfigureProductType(productTypeCode, productTypeName, productOptions);
                string levels = await _productDomainService.ConfigureProductLevel(productLevelCode, productLevelName, productLevelCount);
                string products = await _productDomainService.ConfigureProduct(productShortName, productName, productTypeId, levels, periodClassHour);
                return products;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
