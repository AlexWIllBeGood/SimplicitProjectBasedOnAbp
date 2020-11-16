using DataTransfer.Domain.Entities.Coupan;
using DataTransfer.Domain.Entities.CrmEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DataTransfer.EntityFramework
{
    [ConnectionStringName("ABCCrm")]
    public class ABCCrmDbContext : AbpDbContext<ABCCrmDbContext>
    {
        public DbSet<CrmOrder> CrmOrders { get; set; }
        public DbSet<CrmClassCourse> CrmClassCourses { get; set; }
        public DbSet<CrmDiscountUse> CrmDiscountUses { get; set; }
        public DbSet<CrmProduct> CrmProducts { get; set; }
        public DbSet<CrmBranch> CrmBranchs { get; set; }
        public DbSet<CrmContract> CrmContracts { get; set; }
        public DbSet<CrmLead> CrmLeads { get; set; }
        public DbSet<CrmProductLevel> CrmProductLevels { get; set; }
        public DbSet<CrmUser> CrmUsers { get; set; }
        public DbSet<CrmClassStudent> CrmClassStudents { get; set; }
        public ABCCrmDbContext(DbContextOptions<ABCCrmDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureCrm();
        }
    }
}
