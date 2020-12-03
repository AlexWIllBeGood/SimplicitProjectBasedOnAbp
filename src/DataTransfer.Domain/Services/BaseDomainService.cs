using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace DataTransfer.Domain.Services
{
    //需要使用Autofac才能使用属性注入
    public class BaseDomainService : DomainService
    {
        public IUnitOfWorkManager _unitOfWorkManager;
        public IUnitOfWork _uow
        {
            get
            {
                return _unitOfWorkManager.Current;
            }
        }
        public BaseDomainService(IUnitOfWorkManager unitOfWorkManager)
        {
            this._unitOfWorkManager = unitOfWorkManager;
        }
    }
}
