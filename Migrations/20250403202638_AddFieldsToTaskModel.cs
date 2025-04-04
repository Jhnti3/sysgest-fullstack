using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sysgest_fullstack.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToTaskModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tasks",
                newName: "DataCriacao");

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Tasks",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Tasks",
                newName: "Title");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
