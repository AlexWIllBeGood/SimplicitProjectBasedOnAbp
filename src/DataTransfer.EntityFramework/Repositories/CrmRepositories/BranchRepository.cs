using DataTransfer.Domain.Entities.CrmEntities;
using DataTransfer.Domain.IRepositories.ICrmRepositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework.Repositories.CrmRepositories
{
    public class BranchRepository : EfCoreRepository<ABCCrmDbContext, CrmBranch>, IBranchRepository
    {
        public BranchRepository(IDbContextProvider<ABCCrmDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
