using Microsoft.EntityFrameworkCore.Migrations;

namespace DataTransfer.EntityFramework.DbMigrations.Migrations
{
    public partial class addLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassRelation",
                table: "ClassRelation");

            migrationBuilder.RenameTable(
                name: "ClassRelation",
                newName: "TransferLog");

            migrationBuilder.AlterColumn<int>(
                name: "MTSClassId",
                table: "TransferLog",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CrmClassId",
                table: "TransferLog",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransferLog",
                table: "TransferLog",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TransferLog",
                table: "TransferLog");

            migrationBuilder.RenameTable(
                name: "TransferLog",
                newName: "ClassRelation");

            migrationBuilder.AlterColumn<int>(
                name: "MTSClassId",
                table: "ClassRelation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CrmClassId",
                table: "ClassRelation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassRelation",
                table: "ClassRelation",
                column: "Id");
        }
    }
}
