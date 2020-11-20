using Microsoft.EntityFrameworkCore.Migrations;

namespace DataTransfer.EntityFramework.DbMigrations.Migrations
{
    public partial class addClassTeacher1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "ClassTeacher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "ClassTeacher",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "ClassTeacher");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "ClassTeacher");
        }
    }
}
