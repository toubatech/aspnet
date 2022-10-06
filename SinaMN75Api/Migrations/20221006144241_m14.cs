using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChatEntityProductEntity_GroupChatEntity_GroupChatId",
                table: "GroupChatEntityProductEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupChatEntityUserEntity_GroupChatEntity_GroupChatsId",
                table: "GroupChatEntityUserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupChatMessageEntity_AspNetUsers_UserId",
                table: "GroupChatMessageEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupChatMessageEntity_GroupChatEntity_GroupChatId",
                table: "GroupChatMessageEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_GroupChatEntity_GroupChatId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_GroupChatMessageEntity_GroupChatMessageId",
                table: "Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupChatMessageEntity",
                table: "GroupChatMessageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupChatEntity",
                table: "GroupChatEntity");

            migrationBuilder.RenameTable(
                name: "GroupChatMessageEntity",
                newName: "GroupChatMessage");

            migrationBuilder.RenameTable(
                name: "GroupChatEntity",
                newName: "GroupChat");

            migrationBuilder.RenameIndex(
                name: "IX_GroupChatMessageEntity_UserId",
                table: "GroupChatMessage",
                newName: "IX_GroupChatMessage_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupChatMessageEntity_GroupChatId",
                table: "GroupChatMessage",
                newName: "IX_GroupChatMessage_GroupChatId");

            migrationBuilder.AddColumn<string>(
                name: "ProductOwnerId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupChatMessage",
                table: "GroupChatMessage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupChat",
                table: "GroupChat",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductOwnerId",
                table: "Order",
                column: "ProductOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChatEntityProductEntity_GroupChat_GroupChatId",
                table: "GroupChatEntityProductEntity",
                column: "GroupChatId",
                principalTable: "GroupChat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChatEntityUserEntity_GroupChat_GroupChatsId",
                table: "GroupChatEntityUserEntity",
                column: "GroupChatsId",
                principalTable: "GroupChat",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChatMessage_AspNetUsers_UserId",
                table: "GroupChatMessage",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChatMessage_GroupChat_GroupChatId",
                table: "GroupChatMessage",
                column: "GroupChatId",
                principalTable: "GroupChat",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChatEntityProductEntity_GroupChat_GroupChatId",
                table: "GroupChatEntityProductEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupChatEntityUserEntity_GroupChat_GroupChatsId",
                table: "GroupChatEntityUserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupChatMessage_AspNetUsers_UserId",
                table: "GroupChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupChatMessage_GroupChat_GroupChatId",
                table: "GroupChatMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_GroupChat_GroupChatId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_GroupChatMessage_GroupChatMessageId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_ProductOwnerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductOwnerId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupChatMessage",
                table: "GroupChatMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupChat",
                table: "GroupChat");

            migrationBuilder.DropColumn(
                name: "ProductOwnerId",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "GroupChatMessage",
                newName: "GroupChatMessageEntity");

            migrationBuilder.RenameTable(
                name: "GroupChat",
                newName: "GroupChatEntity");

            migrationBuilder.RenameIndex(
                name: "IX_GroupChatMessage_UserId",
                table: "GroupChatMessageEntity",
                newName: "IX_GroupChatMessageEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupChatMessage_GroupChatId",
                table: "GroupChatMessageEntity",
                newName: "IX_GroupChatMessageEntity_GroupChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupChatMessageEntity",
                table: "GroupChatMessageEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupChatEntity",
                table: "GroupChatEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChatEntityProductEntity_GroupChatEntity_GroupChatId",
                table: "GroupChatEntityProductEntity",
                column: "GroupChatId",
                principalTable: "GroupChatEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChatEntityUserEntity_GroupChatEntity_GroupChatsId",
                table: "GroupChatEntityUserEntity",
                column: "GroupChatsId",
                principalTable: "GroupChatEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChatMessageEntity_AspNetUsers_UserId",
                table: "GroupChatMessageEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChatMessageEntity_GroupChatEntity_GroupChatId",
                table: "GroupChatMessageEntity",
                column: "GroupChatId",
                principalTable: "GroupChatEntity",
                principalColumn: "Id");

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
    }
}
