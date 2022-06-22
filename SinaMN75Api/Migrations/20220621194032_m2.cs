using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorUserId",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CreatorUserId",
                table: "Reports",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_CreatorUserId",
                table: "Reports",
                column: "CreatorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_CreatorUserId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_CreatorUserId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "AspNetUsers");
        }
    }
}
