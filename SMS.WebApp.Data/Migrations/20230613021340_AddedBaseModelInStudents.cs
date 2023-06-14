using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedBaseModelInStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateUserName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdateUserName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateUserName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdateUserName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Students");
        }
    }
}
