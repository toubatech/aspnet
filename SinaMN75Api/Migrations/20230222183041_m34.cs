using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsInsight");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsInsight",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsInsight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsInsight_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductsInsight_ChatReactions_ReactionId",
                        column: x => x.ReactionId,
                        principalTable: "ChatReactions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductsInsight_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInsight_ProductId1",
                table: "ProductsInsight",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInsight_ReactionId",
                table: "ProductsInsight",
                column: "ReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInsight_UserId",
                table: "ProductsInsight",
                column: "UserId");
        }
    }
}
