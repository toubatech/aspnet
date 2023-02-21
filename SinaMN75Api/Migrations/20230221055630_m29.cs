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
                name: "MediaId",
                table: "Bookmarks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_MediaId",
                table: "Bookmarks",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Media_MediaId",
                table: "Bookmarks",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Media_MediaId",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_MediaId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Bookmarks");
        }
    }
}
