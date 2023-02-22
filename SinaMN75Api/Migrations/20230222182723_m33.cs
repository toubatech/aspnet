using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInsight_Products_ProductEntityId",
                table: "ProductsInsight");

            migrationBuilder.RenameColumn(
                name: "ProductEntityId",
                table: "ProductsInsight",
                newName: "ProductId1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInsight_ProductEntityId",
                table: "ProductsInsight",
                newName: "IX_ProductsInsight_ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInsight_Products_ProductId1",
                table: "ProductsInsight",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInsight_Products_ProductId1",
                table: "ProductsInsight");

            migrationBuilder.RenameColumn(
                name: "ProductId1",
                table: "ProductsInsight",
                newName: "ProductEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInsight_ProductId1",
                table: "ProductsInsight",
                newName: "IX_ProductsInsight_ProductEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInsight_Products_ProductEntityId",
                table: "ProductsInsight",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
