using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroupChatId",
                table: "Media",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupChatMessageId",
                table: "Media",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupChatEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UseCase = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ChatStatus = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChatEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupChatEntityProductEntity",
                columns: table => new
                {
                    GroupChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChatEntityProductEntity", x => new { x.GroupChatId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_GroupChatEntityProductEntity_GroupChatEntity_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "GroupChatEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupChatEntityProductEntity_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupChatEntityUserEntity",
                columns: table => new
                {
                    GroupChatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChatEntityUserEntity", x => new { x.GroupChatsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GroupChatEntityUserEntity_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupChatEntityUserEntity_GroupChatEntity_GroupChatsId",
                        column: x => x.GroupChatsId,
                        principalTable: "GroupChatEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupChatMessageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UseCase = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GroupChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChatMessageEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupChatMessageEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupChatMessageEntity_GroupChatEntity_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "GroupChatEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Media_GroupChatId",
                table: "Media",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_GroupChatMessageId",
                table: "Media",
                column: "GroupChatMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatEntityProductEntity_ProductsId",
                table: "GroupChatEntityProductEntity",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatEntityUserEntity_UsersId",
                table: "GroupChatEntityUserEntity",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatMessageEntity_GroupChatId",
                table: "GroupChatMessageEntity",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatMessageEntity_UserId",
                table: "GroupChatMessageEntity",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_GroupChatEntity_GroupChatId",
                table: "Media",
                column: "GroupChatId",
                principalTable: "GroupChatEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_GroupChatMessageEntity_GroupChatMessageId",
                table: "Media",
                column: "GroupChatMessageId",
                principalTable: "GroupChatMessageEntity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_GroupChatEntity_GroupChatId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_GroupChatMessageEntity_GroupChatMessageId",
                table: "Media");

            migrationBuilder.DropTable(
                name: "GroupChatEntityProductEntity");

            migrationBuilder.DropTable(
                name: "GroupChatEntityUserEntity");

            migrationBuilder.DropTable(
                name: "GroupChatMessageEntity");

            migrationBuilder.DropTable(
                name: "GroupChatEntity");

            migrationBuilder.DropIndex(
                name: "IX_Media_GroupChatId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_GroupChatMessageId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "GroupChatId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "GroupChatMessageId",
                table: "Media");
        }
    }
}
