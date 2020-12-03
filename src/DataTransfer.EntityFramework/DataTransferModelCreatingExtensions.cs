using DataTransfer.Domain.Entities.Coupan;
using DataTransfer.Domain.Entities.CrmEntities;
using DataTransfer.Domain.Entities.LocalEntities;
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
            builder.Entity<AddCoupan>(options =>
            {
                options.ConfigureByConvention();
                options.ToTable("AddCoupan");
            });

            builder.Entity<ProductRelation>(options =>
            {
                options.ConfigureByConvention();
                options.ToTable("ProductRelation");
            });

            builder.Entity<ClassRelation>(options =>
            {
                options.ConfigureByConvention();
                options.ToTable("ClassRelation");
            });

            builder.Entity<TransferLog>(options =>
            {
                options.ConfigureByConvention();
                options.ToTable("TransferLog");
                options.HasMany(e => e.TransferLogDetails).WithOne(e => e.TransferLog).HasForeignKey(e => e.TransferLogId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<TransferLogDetail>(options =>
            {
                options.ConfigureByConvention();
                options.ToTable("TransferLogDetail");

            });

            builder.Entity<ClassTeacher>(options =>
            {
                options.ConfigureByConvention();
                options.ToTable("ClassTeacher");
            });

            builder.Entity<ClassHourLevel>(options =>
            {
                options.ConfigureByConvention();
                options.ToTable("ClassHourLevel");
            });
        }

        public static void ConfigureCrm(this ModelBuilder builder)
        {

            builder.Entity<CrmOrder>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("Orders");
            });

            builder.Entity<CrmDiscountUse>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("DiscountUse");
            });

            builder.Entity<CrmClassCourse>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("ClassCourse");
            });

            builder.Entity<CrmProduct>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("Products");
            });

            builder.Entity<CrmBranch>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("Basis_Branch");
            });

            builder.Entity<CrmContract>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("Contract");
            });

            builder.Entity<CrmLead>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("Lead");
            });

            builder.Entity<CrmProductLevel>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("ProductLevel");
            });

            builder.Entity<CrmUser>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("Basis_User");
            });

            builder.Entity<CrmClassStudent>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("ClassStudent");
            });

            builder.Entity<CrmClassSchedule>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("ClassSchedule");
            });

            builder.Entity<CrmProductType>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("ProductType");
            });

            builder.Entity<CrmCaption>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("Basis_Captions");
            });

            builder.Entity<CrmProductSubType>(options =>
            {
                //options.ConfigureByConvention();
                options.ToTable("ProductSubType");
            });
            
        }
    }
}
