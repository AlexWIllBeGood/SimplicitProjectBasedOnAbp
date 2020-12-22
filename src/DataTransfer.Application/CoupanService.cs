using DataTransfer.Application.Contracts.IApplicationServices;
using DataTransfer.Application.CrmServices;
using DataTransfer.Domain.Entities.Coupan;
using DataTransfer.EntityFramework.Repositories;
using DataTransfer.EntityFramework.Repositories.CrmRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace DataTransfer.Application
{
    public class CoupanService : BaseApplicationService
    {
        //private readonly AddCoupanRepository _addCoupanRepository;
        //private readonly CRMOrderRepository _cRMRepository;
        private readonly CRMDisUseRepository _cRMDisUseRepository;
        private readonly ProductRepository _productRepository;
        public CoupanService(
            //AddCoupanRepository addCoupanRepository,
            //CRMOrderRepository cRMRepository,
            CRMDisUseRepository cRMDisUseRepository,
            ProductRepository productRepository,
            IUnitOfWorkManager unitOfWorkManager) : base(unitOfWorkManager)
        {
            //this._addCoupanRepository = addCoupanRepository;
            //this._cRMRepository = cRMRepository;
            this._cRMDisUseRepository = cRMDisUseRepository;
            this._productRepository = productRepository;
        }

        //[UnitOfWork]
        //[Obsolete]
        //public async Task<string> AddCoupanAsync()
        //{
        //    try
        //    {
        //        var newDiscountId = 115;
        //        var originDiscountId = 25;
        //        var startDisuNo = 8885;

        //        //获取历史优惠券数据
        //        var addCoupans = await _addCoupanRepository.GetListAsync();
        //        var orderIds = addCoupans.Select(e => e.OrderId).Distinct().ToList();

        //        var existDisUse = _cRMDisUseRepository.
        //            Where(e => e.Disu_Discount == originDiscountId && orderIds.Contains(e.Disu_FromOrderID))
        //            .ToList();

        //        List<CrmDiscountUse> disuUses = new List<CrmDiscountUse>();

        //        foreach (var ac in addCoupans)
        //        {
        //            var oldDisuUse = existDisUse.FirstOrDefault(e => e.Disu_FromOrderID == ac.OrderId);
        //            if (oldDisuUse != null)
        //            {
        //                for (int i = 0; i < ac.Count; i++)
        //                {
        //                    disuUses.Add(new CrmDiscountUse()
        //                    {
        //                        Disu_Discount = newDiscountId,
        //                        Disu_LeadID = oldDisuUse.Disu_LeadID,
        //                        Disu_Branch = oldDisuUse.Disu_Branch,
        //                        Disu_OrderID = 0,
        //                        Disu_Status = 1,
        //                        Disu_Rate = 0,
        //                        Disu_Amount = 100,
        //                        Disu_WorkflowID = oldDisuUse.Disu_WorkflowID,
        //                        Disu_CreatedBy = 1,
        //                        Disu_CreatedDate = DateTime.Now,
        //                        Disu_UpdatedBy = 1,
        //                        Disu_UpdatedDate = DateTime.Now,
        //                        Disu_Deleted = 0,
        //                        Disu_ExpirationDate = oldDisuUse.Disu_ExpirationDate,
        //                        Disu_FromOrderID = oldDisuUse.Disu_FromOrderID,
        //                        Disu_FromVoucherID = 0,
        //                        Disu_FromID = 0,
        //                        Disu_ToID = 0,
        //                        Disu_FullAmount = 0,
        //                        Disu_Products = null
        //                    });
        //                }
        //            }
        //            else
        //            {

        //            }
        //        }

        //        foreach (var du in disuUses)
        //        {
        //            var no = startDisuNo.ToString().PadLeft(8, '0');
        //            du.Disu_Number = no;
        //            await _cRMDisUseRepository.InsertAsync(du);
        //            startDisuNo++;
        //        }

        //        return disuUses.Count().ToString();
        //    }
        //    catch (Exception ex)
        //    {

        //        return "no";
        //    }
        //    //补偿券
            
        //}

        [UnitOfWork]
        public async Task<string> ChangeCoupanProductAsync()
        {
            try
            {
                string productTypeString = "1,2,3,4,6,7,10,22,23";
                var productTypes = productTypeString.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList().Select<string, int>(e => Convert.ToInt32(e)).ToList();
                List<int> productIds = _productRepository.Where(e => productTypes.Contains((int)e.Prod_Type)).Select(e => e.Prod_ID).ToList();
                string productString = $"[{string.Join(",", productIds)}]";
                var disocuntUses = _cRMDisUseRepository
                    .Where(e => e.Disu_Discount == 1062 && (e.Disu_Amount == 1000 || e.Disu_Amount == 200 || e.Disu_Amount == 300))
                    .ToList();

                foreach (var du in disocuntUses)
                {
                    du.Disu_Products = productString;
                    await _cRMDisUseRepository.UpdateAsync(du);
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
