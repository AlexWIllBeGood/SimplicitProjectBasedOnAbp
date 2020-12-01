﻿// <auto-generated />
using System;
using DataTransfer.EntityFramework.DbMigrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataTransfer.EntityFramework.DbMigrations.Migrations
{
    [DbContext(typeof(LocalMySqlMigrationDbContext))]
    [Migration("20201127084257_changeLog")]
    partial class changeLog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataTransfer.Domain.Entities.Coupan.AddCoupan", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("AddCoupan");
                });

            modelBuilder.Entity("DataTransfer.Domain.Entities.LocalEntities.ClassHourLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ClassHourLevel");
                });

            modelBuilder.Entity("DataTransfer.Domain.Entities.LocalEntities.ClassRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CrmClassId")
                        .HasColumnType("int");

                    b.Property<int?>("MTSClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ClassRelation");
                });

            modelBuilder.Entity("DataTransfer.Domain.Entities.LocalEntities.ClassTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("BranchName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("TeacherName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ClassTeacher");
                });

            modelBuilder.Entity("DataTransfer.Domain.Entities.LocalEntities.ProductRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NewProductName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OriginalProductName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ProductRelation");
                });

            modelBuilder.Entity("DataTransfer.Domain.Entities.LocalEntities.TransferLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BatchNo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("BranchInfo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProductTypeInfo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TransferLog");
                });

            modelBuilder.Entity("DataTransfer.Domain.Entities.LocalEntities.TransferLogDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClassInfo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LeadInfo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Para")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Response")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TransferLogId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransferLogId");

                    b.ToTable("TransferLogDetail");
                });

            modelBuilder.Entity("DataTransfer.Domain.Entities.LocalEntities.TransferLogDetail", b =>
                {
                    b.HasOne("DataTransfer.Domain.Entities.LocalEntities.TransferLog", "TransferLog")
                        .WithMany("TransferLogDetails")
                        .HasForeignKey("TransferLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}