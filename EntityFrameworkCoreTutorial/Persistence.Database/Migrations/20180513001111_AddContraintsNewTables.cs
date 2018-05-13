using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Persistence.Database.Migrations
{
    public partial class AddContraintsNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "Authors",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Albums",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Albums",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedAt",
                table: "Albums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_Title_AlbumId",
                table: "Songs",
                columns: new[] { "Title", "AlbumId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Songs_Title_AlbumId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "PublishedAt",
                table: "Albums");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Albums",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
