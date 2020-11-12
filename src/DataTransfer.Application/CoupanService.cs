using DataTransfer.Domain.Entities.Coupan;
using DataTransfer.EntityFramework.Repositories;
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
    public class CoupanService : ApplicationService
    {
        private readonly AddCoupanRepository _addCoupanRepository;
        private readonly CRMRepository _cRMRepository;
        public CoupanService(AddCoupanRepository addCoupanRepository,CRMRepository cRMRepository)
        {
            this._addCoupanRepository = addCoupanRepository;
            this._cRMRepository = cRMRepository;
        }

        [UnitOfWork]
        [Obsolete]
        public async Task<string> AddCoupanAsync()
        {

            //await _addCoupanRepository.InsertAsync(new AddCoupan()
            //{
            //    OrderId = 1,
            //    OrderNO = "Order1",
            //    StudentName = "Alex",
            //    AddCount = 2
            //});

            try
            {
                var temp = _cRMRepository
                .Where(e => e.Orde_ID == 339)
                .ToList();
            }
            catch (Exception ex)
            {
                return "error";
            }
            
            //throw new Exception("123");
            //CurrentUnitOfWork为什么为null
            //await CurrentUnitOfWork.SaveChangesAsync();
            return "yes";
        }

        /// <summary>
        /// 将代金券信息插入CRM
        /// </summary>
        /// <returns></returns>
        [UnitOfWork]
        public async Task TrasnferCoupanDataToCRM()
        {
            
        }
    }
}
