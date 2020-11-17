using DataTransfer.Domain.Entities.Coupan;
using DataTransfer.Domain.Entities.LocalEntities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework.Repositories
{
    public class ProductRelationRepository : EfCoreRepository<LocalMySqlDbContext, ProductRelation, int>
    {
        public ProductRelationRepository(IDbContextProvider<LocalMySqlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
