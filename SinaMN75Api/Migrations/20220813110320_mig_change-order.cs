using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class mig_changeorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Products_ProductId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Order",
                newName: "TotalPrice");

            migrationBuilder.AddColumn<string>(
                name: "DiscountCode",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DiscountPrice",
                table: "Order",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PayType",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SendPrice",
                table: "Order",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SendType",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderDetailId",
                table: "Forms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    SaleCount = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forms_OrderDetailId",
                table: "Forms",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_OrderDetail_OrderDetailId",
                table: "Forms",
                column: "OrderDetailId",
                principalTable: "OrderDetail",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_OrderDetail_OrderDetailId",
                table: "Forms");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_Forms_OrderDetailId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "DiscountCode",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PayType",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "SendPrice",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "SendType",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "Forms");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Order",
                newName: "Price");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Products_ProductId",
                table: "Order",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
