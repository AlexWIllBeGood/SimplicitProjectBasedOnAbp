using DataTransfer.Domain.Entities.Coupan;
using DataTransfer.Domain.Entities.LocalEntities;
using DataTransfer.Domain.IRepositories.ILocalRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework.Repositories
{
    public class ClassHourLevelRepository : EfCoreRepository<LocalMySqlDbContext, ClassHourLevel, int>, IClassHourLevelRepository
    {
        public ClassHourLevelRepository(IDbContextProvider<LocalMySqlDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
