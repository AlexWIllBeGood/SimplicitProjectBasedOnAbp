using DataTransfer.Domain.Entities.Coupan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DataTransfer.EntityFramework
{
    public static class DataTransferModelCreatingExtensions
    {
        public static void ConfigureLocal(this ModelBuilder builder)
        {
            //TODO
            builder.Entity<AddCoupan>(options=> {
                options.ConfigureByConvention();
                options.ToTable("AddCoupan");
            });
        }

        public static void ConfigureCrm(this ModelBuilder builder)
        {
            //TODO
            builder.Entity<CrmOrder>(options => {
                //options.ConfigureByConvention();
                options.ToTable("Orders");
            });
        }
    }
}
