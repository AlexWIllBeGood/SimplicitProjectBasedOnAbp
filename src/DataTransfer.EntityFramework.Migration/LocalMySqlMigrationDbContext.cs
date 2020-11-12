using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework.DbMigrations
{
    public class LocalMySqlMigrationDbContext : DbContext
    {
        public LocalMySqlMigrationDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureLocal();
        }
    }
}
