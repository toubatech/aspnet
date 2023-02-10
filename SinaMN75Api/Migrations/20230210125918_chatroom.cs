using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class chatroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductUseCase",
                table: "Order",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChatRoom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Users = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    PrivateLikeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReadPrivateMessage = table.Column<bool>(type: "bit", nullable: false),
                    RepliedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_ChatRoom_ChatRoomId",
                        column: x => x.ChatRoomId,
                        principalTable: "ChatRoom",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Emoji",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmojiEnum = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emoji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emoji_ChatMessages_ChatMessageId",
                        column: x => x.ChatMessageId,
                        principalTable: "ChatMessages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LikeDislike",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsLiked = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeDislike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikeDislike_ChatMessages_ChatMessageId",
                        column: x => x.ChatMessageId,
                        principalTable: "ChatMessages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeenMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSeen = table.Column<bool>(type: "bit", nullable: false),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeenMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeenMessage_ChatMessages_ChatMessageId",
                        column: x => x.ChatMessageId,
                        principalTable: "ChatMessages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChatRoomId",
                table: "ChatMessages",
                column: "ChatRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_PrivateLikeId",
                table: "ChatMessages",
                column: "PrivateLikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Emoji_ChatMessageId",
                table: "Emoji",
                column: "ChatMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeDislike_ChatMessageId",
                table: "LikeDislike",
                column: "ChatMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_SeenMessage_ChatMessageId",
                table: "SeenMessage",
                column: "ChatMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_LikeDislike_PrivateLikeId",
                table: "ChatMessages",
                column: "PrivateLikeId",
                principalTable: "LikeDislike",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_ChatRoom_ChatRoomId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_LikeDislike_PrivateLikeId",
                table: "ChatMessages");

            migrationBuilder.DropTable(
                name: "Emoji");

            migrationBuilder.DropTable(
                name: "SeenMessage");

            migrationBuilder.DropTable(
                name: "ChatRoom");

            migrationBuilder.DropTable(
                name: "LikeDislike");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "ProductUseCase",
                table: "Order");
        }
    }
}
