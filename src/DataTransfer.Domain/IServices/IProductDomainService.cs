using DataTransfer.Domain.Entities.CrmEntities;
using DataTransfer.Domain.Entities.Temp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace DataTransfer.Domain.IServices
{
    public interface IProductDomainService : IDomainService
    {
        public Task<int> ConfigureProductType(string productTypeCode, string productTypeName, List<ProductOption> productOptions);
        public Task<string> ConfigureProductLevel(string productLevelCode, string productLevelName, int productLevelCount);
        public Task<string> ConfigureProduct(string shortName, string productName, int productTypeId, string productLevelIds, int periodClassHour);
    }
}
