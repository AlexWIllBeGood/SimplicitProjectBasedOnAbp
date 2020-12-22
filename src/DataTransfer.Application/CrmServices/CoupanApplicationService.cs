using DataTransfer.Application.Contracts.IApplicationServices;
using DataTransfer.Domain.IRepositories.ICrmRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Uow;

namespace DataTransfer.Application.CrmServices
{
    public class CoupanApplicationService : BaseApplicationService, ICoupanApplicationService
    {
        private readonly IProductRepository _productRepository;
        private readonly IDiscountUseRepository _discountUseRepository;
        public CoupanApplicationService(IUnitOfWorkManager unitOfWorkManager,
           IProductRepository productRepository,
           IDiscountUseRepository discountUseRepository
           ) : base(unitOfWorkManager)
        {
            this._productRepository = productRepository;
            this._discountUseRepository = discountUseRepository;
        }
        [UnitOfWork]
        public async Task<string> ChangeCoupanProductAsync()
        {
            try
            {
                string productTypeString = "1,2,3,4,6,7,10,22,23";
                var productTypes = productTypeString.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList().Select<string, int>(e => Convert.ToInt32(e)).ToList();
                List<int> productIds = _productRepository.Where(e => productTypes.Contains((int)e.Prod_Type)).Select(e => e.Prod_ID).ToList();
                string productString = $"[{string.Join(",", productIds)}]";
                var disocuntUses = _discountUseRepository
                    .Where(e => e.Disu_Discount == 118 && e.Disu_ExpirationDate != null &&e.Disu_Amount==1000)
                    .ToList();

                foreach (var du in disocuntUses)
                {
                    du.Disu_Products = productString;
                    await _discountUseRepository.UpdateAsync(du);
                }

                return disocuntUses.Count.ToString();
            }
            catch (Exception)
            {

                return "error";
            }
        }
    }
}
