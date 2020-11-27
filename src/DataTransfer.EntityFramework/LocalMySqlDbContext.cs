using DataTransfer.Domain.Entities.Coupan;
using DataTransfer.Domain.Entities.LocalEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework
{
    [ConnectionStringName("LocalMysql")]
    public class LocalMySqlDbContext : AbpDbContext<LocalMySqlDbContext>
    {
        public DbSet<ProductRelation> ProductRelations { get; set; }
        public DbSet<ClassRelation> ClassRelations { get; set; }
        public DbSet<TransferLog> TransferLogs { get; set; }
        public DbSet<TransferLogDetail> TransferLogDetails { get; set; }
        public DbSet<ClassTeacher> ClassTeachers { get; set; }
        public DbSet<ClassHourLevel> ClassHourLevels { get; set; }
        public LocalMySqlDbContext(DbContextOptions<LocalMySqlDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureLocal();
        }
    }
}
