using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookmarkId",
                table: "Media",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.DropColumn(
                name: "BookmarkId",
                table: "Media");
        }
    }
}
