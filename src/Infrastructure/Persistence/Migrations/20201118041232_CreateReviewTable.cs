using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeClinic.Infrastructure.Persistence.Migrations
{
    public partial class CreateReviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueTickets_Categories_CategoryId",
                table: "IssueTickets");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    IssueTicketId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_IssueTickets_IssueTicketId",
                        column: x => x.IssueTicketId,
                        principalTable: "IssueTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IssueTicketId",
                table: "Reviews",
                column: "IssueTicketId");

            migrationBuilder.AddForeignKey(
                name: "CategoryIssueTickets",
                table: "IssueTickets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "CategoryIssueTickets",
                table: "IssueTickets");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueTickets_Categories_CategoryId",
                table: "IssueTickets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
