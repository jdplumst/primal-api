﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddHabitatDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Habitat",
                type: "text",
                nullable: false,
                defaultValue: ""
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Description", table: "Habitat");
        }
    }
}
