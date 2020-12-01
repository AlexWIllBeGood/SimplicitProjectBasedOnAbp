using DataTransfer.Domain.Entities.Coupan;
using DataTransfer.Domain.Entities.CrmEntities;
using DataTransfer.Domain.IRepositories.ICrmRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework.Repositories.CrmRepositories
{
    public class DiscountUseRepository : EfCoreRepository<ABCCrmDbContext,CrmDiscountUse>, IDiscountUseRepository
    {
        public DiscountUseRepository(IDbContextProvider<ABCCrmDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
