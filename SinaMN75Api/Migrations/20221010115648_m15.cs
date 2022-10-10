using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Products_ProductId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_ProductId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Chats");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ChatId",
                table: "Products",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Chats_ChatId",
                table: "Products",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Chats_ChatId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ChatId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Chats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ProductId",
                table: "Chats",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Products_ProductId",
                table: "Chats",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
