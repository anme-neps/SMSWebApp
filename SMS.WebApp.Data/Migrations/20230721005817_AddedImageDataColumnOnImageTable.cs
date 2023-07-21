﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageDataColumnOnImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Images",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Images");
        }
    }
}
