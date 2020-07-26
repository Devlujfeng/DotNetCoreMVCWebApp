using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApp.Data.Migrations.AdventureWorks2017
{
    public partial class adventureWorksNew2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "OrganizationLevel",
                schema: "HumanResources",
                table: "Employee",
                nullable: true,
                computedColumnSql: "([OrganizationNode].[GetLevel]())",
                comment: "The depth of the employee in the corporate hierarchy.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationLevel",
                schema: "HumanResources",
                table: "Employee");
        }
    }
}
