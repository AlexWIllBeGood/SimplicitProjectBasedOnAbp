using DataTransfer.Domain.Entities.Coupan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework.Repositories
{
    public class CRMDisUseRepository : EfCoreRepository<ABCCrmDbContext, CrmDiscountUse, int>
    {
        public CRMDisUseRepository(IDbContextProvider<ABCCrmDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
