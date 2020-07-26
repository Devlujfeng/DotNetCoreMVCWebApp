using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApp.Data.Migrations.AdventureWorks2017
{
    public partial class adventureWorksNew10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "PXML_Person_AddContact",
                schema: "Person",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "PXML_Person_AddContact",
                schema: "Person",
                table: "Person",
                column: "AdditionalContactInfo");
        }
    }
}
