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
    public class CRMOrderRepository : EfCoreRepository<ABCCrmDbContext, CrmOrder, int>, ICRMOrderRepository
    {
        public CRMOrderRepository(IDbContextProvider<ABCCrmDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
