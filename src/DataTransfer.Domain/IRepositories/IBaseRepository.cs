using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

namespace DataTransfer.Domain.IRepositories
{
    public interface IBaseRepository<TEntity> : IEfCoreRepository<TEntity> where TEntity : class, IEntity
    {
    }
}
