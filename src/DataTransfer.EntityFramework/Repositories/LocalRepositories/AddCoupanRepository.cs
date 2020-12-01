using DataTransfer.Domain.Entities.Coupan;
using DataTransfer.Domain.IRepositories.ILocalRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework.Repositories
{
    public class AddCoupanRepository : EfCoreRepository<LocalMySqlDbContext, AddCoupan, int>, IAddCoupanRepository
    {
        public AddCoupanRepository(IDbContextProvider<LocalMySqlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
