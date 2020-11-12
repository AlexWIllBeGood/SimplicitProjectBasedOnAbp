using DataTransfer.Domain.Entities.Coupan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework.Repositories
{
    public class CRMRepository : EfCoreRepository<ABCCrmDbContext, CrmOrder, int>
    {
        public CRMRepository(IDbContextProvider<ABCCrmDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
