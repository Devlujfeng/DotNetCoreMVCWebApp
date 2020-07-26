using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApp.Data.Migrations
{
    public partial class initialcreatety : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityTest",
                columns: table => new
                {
                    PartitionKey = table.Column<string>(nullable: true),
                    RowKey = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTimeOffset>(nullable: false),
                    ETag = table.Column<string>(nullable: true),
                    id_internal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    entity_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTest", x => x.id_internal);
                });

            migrationBuilder.CreateTable(
                name: "RelationshipTest",
                columns: table => new
                {
                    PartitionKey = table.Column<string>(nullable: true),
                    RowKey = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTimeOffset>(nullable: false),
                    ETag = table.Column<string>(nullable: true),
                    guid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_internal = table.Column<int>(nullable: false),
                    id_internal_ref = table.Column<int>(nullable: false),
                    typeRelationship = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationshipTest", x => x.guid);
                    table.ForeignKey(
                        name: "FK_RelationshipTest_EntityTest_id_internal",
                        column: x => x.id_internal,
                        principalTable: "EntityTest",
                        principalColumn: "id_internal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelationshipTest_id_internal",
                table: "RelationshipTest",
                column: "id_internal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelationshipTest");

            migrationBuilder.DropTable(
                name: "EntityTest");
        }
    }
}
