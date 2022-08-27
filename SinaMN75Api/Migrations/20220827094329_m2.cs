using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MaxPrice",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinPrice",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VoteCount",
                table: "Products",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VoteCount",
                table: "Products");
        }
    }
}
