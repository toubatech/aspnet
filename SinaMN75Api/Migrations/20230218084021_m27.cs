using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reaction",
                table: "ProductsInsight",
                newName: "Count");

            migrationBuilder.AddColumn<Guid>(
                name: "ReactionId",
                table: "ProductsInsight",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFollowing",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ChatRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Users = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MessageText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ReadPrivateMessage = table.Column<bool>(type: "bit", nullable: true),
                    RepliedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersMentioned = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceIdType = table.Column<int>(type: "int", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChatRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_ChatRooms_ChatRoomId",
                        column: x => x.ChatRoomId,
                        principalTable: "ChatRooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChatReactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reaction = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChatMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatReactions_ChatMessages_ChatMessageId",
                        column: x => x.ChatMessageId,
                        principalTable: "ChatMessages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SeenMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSeen = table.Column<bool>(type: "bit", nullable: false),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChatMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeenMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeenMessages_ChatMessages_ChatMessageId",
                        column: x => x.ChatMessageId,
                        principalTable: "ChatMessages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInsight_ReactionId",
                table: "ProductsInsight",
                column: "ReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChatRoomId",
                table: "ChatMessages",
                column: "ChatRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatReactions_ChatMessageId",
                table: "ChatReactions",
                column: "ChatMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_SeenMessages_ChatMessageId",
                table: "SeenMessages",
                column: "ChatMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInsight_ChatReactions_ReactionId",
                table: "ProductsInsight",
                column: "ReactionId",
                principalTable: "ChatReactions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInsight_ChatReactions_ReactionId",
                table: "ProductsInsight");

            migrationBuilder.DropTable(
                name: "ChatReactions");

            migrationBuilder.DropTable(
                name: "SeenMessages");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "ChatRooms");

            migrationBuilder.DropIndex(
                name: "IX_ProductsInsight_ReactionId",
                table: "ProductsInsight");

            migrationBuilder.DropColumn(
                name: "ReactionId",
                table: "ProductsInsight");

            migrationBuilder.DropColumn(
                name: "IsFollowing",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "ProductsInsight",
                newName: "Reaction");
        }
    }
}
