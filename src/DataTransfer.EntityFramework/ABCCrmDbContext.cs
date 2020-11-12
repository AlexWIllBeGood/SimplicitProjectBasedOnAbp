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
    [ConnectionStringName("ABCCrm")]
    public class ABCCrmDbContext : AbpDbContext<ABCCrmDbContext>
    {
        public DbSet<CrmOrder> CrmOrders { get; set; }
        public ABCCrmDbContext(DbContextOptions<ABCCrmDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureCrm();
        }
    }
}
