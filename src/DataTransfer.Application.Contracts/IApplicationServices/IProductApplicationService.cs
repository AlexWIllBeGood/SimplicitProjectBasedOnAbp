using DataTransfer.Domain.Entities.Temp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DataTransfer.Application.Contracts.IApplicationServices
{
    public interface IProductApplicationService : IApplicationService
    {
        Task<string> ConfigureProduct(
            string productTypeCode, string productTypeName, List<ProductOption> productOptions,
            string productLevelCode, string productLevelName, int productLevelCount,
            string productShortName, string productName, int periodClassHour);
    }
}
