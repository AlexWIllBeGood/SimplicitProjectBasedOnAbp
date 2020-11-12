using DataTransfer.Domain.Entities.Coupan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework
{
    [ConnectionStringName("Default")]
    public class LocalMySqlDbContext : AbpDbContext<LocalMySqlDbContext>
    {
        public DbSet<AddCoupan> AddCoupans { get; set; }
        public LocalMySqlDbContext(DbContextOptions<LocalMySqlDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureDataTransfer();
        }
    }
}
