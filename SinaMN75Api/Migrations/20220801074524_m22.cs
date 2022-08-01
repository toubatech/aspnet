using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value1",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value10",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value11",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value12",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value3",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value4",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value5",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value6",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value7",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value8",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value9",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccessLevel",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Value1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Value10",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Value11",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Value12",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Value2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Value3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Value4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Value5",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Value6",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Value7",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Value8",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Value9",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AccessLevel",
                table: "AspNetUsers");

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
        }
    }
}
