using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApp.Data.Migrations.AdventureWorks2017
{
    public partial class adventureWorksNew5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                schema: "Sales",
                table: "Customer",
                unicode: false,
                maxLength: 10,
                nullable: false,
                computedColumnSql: "(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))",
                comment: "Unique number identifying the customer assigned by the accounting system.",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldComment: "Unique number identifying the customer assigned by the accounting system.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                schema: "Sales",
                table: "Customer",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                comment: "Unique number identifying the customer assigned by the accounting system.",
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 10,
                oldComputedColumnSql: "(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))",
                oldComment: "Unique number identifying the customer assigned by the accounting system.");
        }
    }
}
