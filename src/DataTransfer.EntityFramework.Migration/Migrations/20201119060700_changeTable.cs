using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataTransfer.EntityFramework.DbMigrations.Migrations
{
    public partial class changeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrmClassId",
                table: "TransferLog");

            migrationBuilder.DropColumn(
                name: "MTSClassId",
                table: "TransferLog");

            migrationBuilder.AddColumn<string>(
                name: "BatchNo",
                table: "TransferLog",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "TransferLog",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Para",
                table: "TransferLog",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Response",
                table: "TransferLog",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "TransferLog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ClassRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CrmClassId = table.Column<int>(nullable: true),
                    MTSClassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRelation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassRelation");

            migrationBuilder.DropColumn(
                name: "BatchNo",
                table: "TransferLog");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "TransferLog");

            migrationBuilder.DropColumn(
                name: "Para",
                table: "TransferLog");

            migrationBuilder.DropColumn(
                name: "Response",
                table: "TransferLog");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "TransferLog");

            migrationBuilder.AddColumn<int>(
                name: "CrmClassId",
                table: "TransferLog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MTSClassId",
                table: "TransferLog",
                type: "int",
                nullable: true);
        }
    }
}
