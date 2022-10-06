using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Categories",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryEntityOrderDetailEntity",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEntityOrderDetailEntity", x => new { x.CategoriesId, x.OrderDetailsId });
                    table.ForeignKey(
                        name: "FK_CategoryEntityOrderDetailEntity_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryEntityOrderDetailEntity_OrderDetail_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "OrderDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEntityOrderDetailEntity_OrderDetailsId",
                table: "CategoryEntityOrderDetailEntity",
                column: "OrderDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryEntityOrderDetailEntity");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Categories");
        }
    }
}
