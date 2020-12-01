using DataTransfer.Domain.Entities.CrmEntities;
using DataTransfer.Domain.IRepositories.ICrmRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework.Repositories.CrmRepositories
{
    public class ProductRepository : EfCoreRepository<ABCCrmDbContext, CrmProduct>, IProductRepository
    {
        public ProductRepository(IDbContextProvider<ABCCrmDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
