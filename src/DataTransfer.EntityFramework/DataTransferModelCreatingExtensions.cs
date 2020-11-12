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
        public static void ConfigureDataTransfer(this ModelBuilder builder)
        {
            //TODO
            builder.Entity<AddCoupan>(options=> {
                options.ConfigureByConvention();
                options.ToTable("AddCoupan");
            });
        }
    }
}
