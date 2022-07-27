using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KeyValues1",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyValues2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date1",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date2",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Categories",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Categories",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyValues1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "KeyValues2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Date1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Date2",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Categories");
        }
    }
}
