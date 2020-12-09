using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.Uow;

namespace DataTransfer.Application.CrmServices
{
    public class BaseApplicationService : ApplicationService
    {
        public IUnitOfWorkManager _unitOfWorkManager;
        public IUnitOfWork _uow
        {
            get
            {
                return _unitOfWorkManager.Current;
            }
        }
        public BaseApplicationService(IUnitOfWorkManager unitOfWorkManager)
        {
            this._unitOfWorkManager = unitOfWorkManager;
        }
    }
}
