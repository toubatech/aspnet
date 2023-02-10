using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormFields_FormFields_ParentId",
                table: "FormFields");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_GroupChat_GroupChatId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_GroupChatMessage_GroupChatMessageId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_ProductOwnerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Chats_ChatId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "GroupChatEntityProductEntity");

            migrationBuilder.DropTable(
                name: "GroupChatEntityUserEntity");

            migrationBuilder.DropTable(
                name: "GroupChatMessage");

            migrationBuilder.DropTable(
                name: "GroupChat");

            migrationBuilder.DropIndex(
                name: "IX_Products_ChatId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductOwnerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Media_GroupChatId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_GroupChatMessageId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_FormFields_ParentId",
                table: "FormFields");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductOwnerId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductUseCase",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "GroupChatId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "GroupChatMessageId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "UseCase",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "FormFields");

            migrationBuilder.DropColumn(
                name: "UseCase",
                table: "FormFields");

            migrationBuilder.DropColumn(
                name: "UseCase2",
                table: "FormFields");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChatId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductOwnerId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductUseCase",
                table: "Order",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "UseCase",
                table: "Forms",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "FormFields",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UseCase",
                table: "FormFields",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UseCase2",
                table: "FormFields",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "GroupChat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatStatus = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UseCase = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChat", x => x.Id);
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
                        name: "FK_GroupChatEntityProductEntity_GroupChat_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "GroupChat",
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
                        name: "FK_GroupChatEntityUserEntity_GroupChat_GroupChatsId",
                        column: x => x.GroupChatsId,
                        principalTable: "GroupChat",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupChatMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UseCase = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChatMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupChatMessage_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupChatMessage_GroupChat_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "GroupChat",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ChatId",
                table: "Products",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductOwnerId",
                table: "Order",
                column: "ProductOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_GroupChatId",
                table: "Media",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_GroupChatMessageId",
                table: "Media",
                column: "GroupChatMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_FormFields_ParentId",
                table: "FormFields",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatEntityProductEntity_ProductsId",
                table: "GroupChatEntityProductEntity",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatEntityUserEntity_UsersId",
                table: "GroupChatEntityUserEntity",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatMessage_GroupChatId",
                table: "GroupChatMessage",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatMessage_UserId",
                table: "GroupChatMessage",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormFields_FormFields_ParentId",
                table: "FormFields",
                column: "ParentId",
                principalTable: "FormFields",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_GroupChat_GroupChatId",
                table: "Media",
                column: "GroupChatId",
                principalTable: "GroupChat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_GroupChatMessage_GroupChatMessageId",
                table: "Media",
                column: "GroupChatMessageId",
                principalTable: "GroupChatMessage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_ProductOwnerId",
                table: "Order",
                column: "ProductOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Chats_ChatId",
                table: "Products",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id");
        }
    }
}
