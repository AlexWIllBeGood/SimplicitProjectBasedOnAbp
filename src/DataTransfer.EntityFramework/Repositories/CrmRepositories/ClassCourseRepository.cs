using DataTransfer.Domain.Entities.CrmEntities;
using DataTransfer.Domain.IRepositories.ICrmRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework.Repositories.CrmRepositories
{
    public class ClassCourseRepository : EfCoreRepository<ABCCrmDbContext, CrmClassCourse>, IClassCourseRepository
    {
        public ClassCourseRepository(IDbContextProvider<ABCCrmDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
