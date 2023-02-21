using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Bookmarks_BookmarkEntityId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_BookmarkEntityId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "BookmarkEntityId",
                table: "Media");

            migrationBuilder.CreateIndex(
                name: "IX_Media_BookmarkId",
                table: "Media",
                column: "BookmarkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Bookmarks_BookmarkId",
                table: "Media",
                column: "BookmarkId",
                principalTable: "Bookmarks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Bookmarks_BookmarkId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_BookmarkId",
                table: "Media");

            migrationBuilder.AddColumn<Guid>(
                name: "BookmarkEntityId",
                table: "Media",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_BookmarkEntityId",
                table: "Media",
                column: "BookmarkEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Bookmarks_BookmarkEntityId",
                table: "Media",
                column: "BookmarkEntityId",
                principalTable: "Bookmarks",
                principalColumn: "Id");
        }
    }
}
