using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeClinic.Infrastructure.Persistence.Migrations
{
    public partial class CreateCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "IssueTickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueTickets_CategoryId",
                table: "IssueTickets",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueTickets_Categories_CategoryId",
                table: "IssueTickets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueTickets_Categories_CategoryId",
                table: "IssueTickets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_IssueTickets_CategoryId",
                table: "IssueTickets");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "IssueTickets");
        }
    }
}
