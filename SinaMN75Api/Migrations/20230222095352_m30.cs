using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitProducts_Products_ProductEntityId",
                table: "VisitProducts");

            migrationBuilder.RenameColumn(
                name: "ProductEntityId",
                table: "VisitProducts",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_VisitProducts_ProductEntityId",
                table: "VisitProducts",
                newName: "IX_VisitProducts_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitProducts_Products_ProductsId",
                table: "VisitProducts",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitProducts_Products_ProductsId",
                table: "VisitProducts");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "VisitProducts",
                newName: "ProductEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_VisitProducts_ProductsId",
                table: "VisitProducts",
                newName: "IX_VisitProducts_ProductEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitProducts_Products_ProductEntityId",
                table: "VisitProducts",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
