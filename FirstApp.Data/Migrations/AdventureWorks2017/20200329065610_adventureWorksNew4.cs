using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApp.Data.Migrations.AdventureWorks2017
{
    public partial class adventureWorksNew4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "AK_Customer_AccountNumber",
                schema: "Sales",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                schema: "Sales",
                table: "Customer",
                unicode: false,
                maxLength: 10,
                nullable: false,
                comment: "Unique number identifying the customer assigned by the accounting system.",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "AK_Customer_AccountNumber",
                schema: "Sales",
                table: "Customer",
                column: "AccountNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "AK_Customer_AccountNumber",
                schema: "Sales",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                schema: "Sales",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 10,
                oldComment: "Unique number identifying the customer assigned by the accounting system.");

            migrationBuilder.CreateIndex(
                name: "AK_Customer_AccountNumber",
                schema: "Sales",
                table: "Customer",
                column: "AccountNumber",
                unique: true,
                filter: "[AccountNumber] IS NOT NULL");
        }
    }
}
