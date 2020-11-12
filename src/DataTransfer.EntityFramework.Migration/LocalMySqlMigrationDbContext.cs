using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework.Migration
{
    public class LocalMySqlMigrationDbContext : AbpDbContext<LocalMySqlMigrationDbContext>
    {
        public LocalMySqlMigrationDbContext(DbContextOptions<LocalMySqlMigrationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureDataTransfer();
        }
    }
}
