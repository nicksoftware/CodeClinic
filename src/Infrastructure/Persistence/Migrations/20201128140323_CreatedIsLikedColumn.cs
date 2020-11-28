using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeClinic.Infrastructure.Persistence.Migrations
{
    public partial class CreatedIsLikedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "Likes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "Likes");
        }
    }
}
