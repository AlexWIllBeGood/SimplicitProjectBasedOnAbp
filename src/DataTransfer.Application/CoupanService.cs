using DataTransfer.Domain.Entities.Coupan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace DataTransfer.Application
{
    public class CoupanService : ApplicationService
    {
        private readonly IRepository<AddCoupan> _addCoupanRepository;
        public CoupanService(IRepository<AddCoupan> addCoupanRepository)
        {
            this._addCoupanRepository = addCoupanRepository;
        }

        [UnitOfWork]
        public async Task<string> AddCoupanAsync()
        {
            //await _addCoupanRepository.InsertAsync(new AddCoupan()
            //{
            //    OrderId = 1,
            //    OrderNO = "Order1",
            //    StudentName = "Alex",
            //    AddCount = 2
            //});
            //CurrentUnitOfWork为什么为null
            //await CurrentUnitOfWork.SaveChangesAsync();
            return "yes";
        }
    }
}
