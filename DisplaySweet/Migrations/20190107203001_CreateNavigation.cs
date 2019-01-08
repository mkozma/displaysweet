using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DisplaySweet.Migrations
{
    public partial class CreateNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NavigationId",
                table: "Components",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NavigationId1",
                table: "Components",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Navigation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navigation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_NavigationId",
                table: "Components",
                column: "NavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_NavigationId1",
                table: "Components",
                column: "NavigationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Navigation_NavigationId",
                table: "Components",
                column: "NavigationId",
                principalTable: "Navigation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Navigation_NavigationId1",
                table: "Components",
                column: "NavigationId1",
                principalTable: "Navigation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Navigation_NavigationId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Components_Navigation_NavigationId1",
                table: "Components");

            migrationBuilder.DropTable(
                name: "Navigation");

            migrationBuilder.DropIndex(
                name: "IX_Components_NavigationId",
                table: "Components");

            migrationBuilder.DropIndex(
                name: "IX_Components_NavigationId1",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "NavigationId",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "NavigationId1",
                table: "Components");
        }
    }
}
