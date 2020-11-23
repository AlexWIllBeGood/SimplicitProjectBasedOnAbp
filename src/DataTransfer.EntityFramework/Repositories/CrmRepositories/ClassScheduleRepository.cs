using DataTransfer.Domain.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework.Repositories.CrmRepositories
{
    public class ClassScheduleRepository : EfCoreRepository<ABCCrmDbContext, CrmClassSchedule>
    {
        public ClassScheduleRepository(IDbContextProvider<ABCCrmDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
