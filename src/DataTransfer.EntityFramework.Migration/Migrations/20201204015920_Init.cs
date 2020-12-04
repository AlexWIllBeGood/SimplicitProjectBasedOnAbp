using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataTransfer.EntityFramework.DbMigrations.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddCoupan",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddCoupan", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "ClassHourLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Hour = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassHourLevel", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "ClassTeacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BranchName = table.Column<string>(nullable: true),
                    ClassName = table.Column<string>(nullable: true),
                    TeacherName = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: true),
                    ClassId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTeacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OriginalProductName = table.Column<string>(nullable: true),
                    NewProductName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRelation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BatchNo = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    ProductTypeInfo = table.Column<string>(nullable: true),
                    BranchInfo = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferLogDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TransferLogId = table.Column<int>(nullable: false),
                    LeadInfo = table.Column<string>(nullable: true),
                    ClassInfo = table.Column<string>(nullable: true),
                    Para = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferLogDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferLogDetail_TransferLog_TransferLogId",
                        column: x => x.TransferLogId,
                        principalTable: "TransferLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransferLogDetail_TransferLogId",
                table: "TransferLogDetail",
                column: "TransferLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddCoupan");

            migrationBuilder.DropTable(
                name: "ClassHourLevel");

            migrationBuilder.DropTable(
                name: "ClassRelation");

            migrationBuilder.DropTable(
                name: "ClassTeacher");

            migrationBuilder.DropTable(
                name: "ProductRelation");

            migrationBuilder.DropTable(
                name: "TransferLogDetail");

            migrationBuilder.DropTable(
                name: "TransferLog");
        }
    }
}
