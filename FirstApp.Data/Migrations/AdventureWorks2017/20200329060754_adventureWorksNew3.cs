using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApp.Data.Migrations.AdventureWorks2017
{
    public partial class adventureWorksNew3 : Migration
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
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldComputedColumnSql: "(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))",
                oldComment: "Unique number identifying the customer assigned by the accounting system.");

            migrationBuilder.CreateIndex(
                name: "AK_Customer_AccountNumber",
                schema: "Sales",
                table: "Customer",
                column: "AccountNumber",
                unique: true,
                filter: "[AccountNumber] IS NOT NULL");
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
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                computedColumnSql: "(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))",
                comment: "Unique number identifying the customer assigned by the accounting system.",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "AK_Customer_AccountNumber",
                schema: "Sales",
                table: "Customer",
                column: "AccountNumber",
                unique: true);
        }
    }
}
