﻿// <auto-generated />
using DataTransfer.EntityFramework.DbMigrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataTransfer.EntityFramework.DbMigrations.Migrations
{
    [DbContext(typeof(LocalMySqlMigrationDbContext))]
    [Migration("20201116102623_Init")]
    partial class Init
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
#pragma warning restore 612, 618
        }
    }
}