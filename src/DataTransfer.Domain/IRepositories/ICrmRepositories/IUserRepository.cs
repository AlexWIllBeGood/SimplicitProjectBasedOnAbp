using System;
using System.Collections.Generic;
using System.Text;
using DataTransfer.Domain.Entities.CrmEntities;

namespace DataTransfer.Domain.IRepositories.ICrmRepositories
{
    public interface IUserRepository : IBaseRepository<CrmUser>
    {
    }
}
