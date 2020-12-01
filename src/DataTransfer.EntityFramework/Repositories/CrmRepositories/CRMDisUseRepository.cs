using DataTransfer.Domain.Entities.Coupan;
using DataTransfer.Domain.IRepositories.ICrmRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework.Repositories
{
    public class CRMDisUseRepository : EfCoreRepository<ABCCrmDbContext, CrmDiscountUse, int>, ICRMDisUseRepository
    {
        public CRMDisUseRepository(IDbContextProvider<ABCCrmDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
