using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinaMN75Api.Migrations
{
    public partial class m19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "FormFields",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormFields_ParentId",
                table: "FormFields",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormFields_FormFields_ParentId",
                table: "FormFields",
                column: "ParentId",
                principalTable: "FormFields",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormFields_FormFields_ParentId",
                table: "FormFields");

            migrationBuilder.DropIndex(
                name: "IX_FormFields_ParentId",
                table: "FormFields");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "FormFields");
        }
    }
}
