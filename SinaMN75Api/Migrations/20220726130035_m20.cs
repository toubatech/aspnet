using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Capacity",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Capacity1",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Capacity10",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Capacity11",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Capacity12",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Capacity2",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Capacity3",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Capacity4",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Capacity5",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Capacity6",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Capacity7",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Capacity8",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Capacity9",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Packaging",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Port",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shipping",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Capacity1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Capacity10",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Capacity11",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Capacity12",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Capacity2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Capacity3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Capacity4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Capacity5",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Capacity6",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Capacity7",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Capacity8",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Capacity9",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Packaging",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Port",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Shipping",
                table: "Products");
        }
    }
}
