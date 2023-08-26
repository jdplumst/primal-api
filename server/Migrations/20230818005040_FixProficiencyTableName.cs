using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixProficiencyTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonProficiency_Prociciency_ProficienciesId",
                table: "PokemonProficiency");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prociciency",
                table: "Prociciency");

            migrationBuilder.RenameTable(
                name: "Prociciency",
                newName: "Proficiency");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proficiency",
                table: "Proficiency",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonProficiency_Proficiency_ProficienciesId",
                table: "PokemonProficiency",
                column: "ProficienciesId",
                principalTable: "Proficiency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonProficiency_Proficiency_ProficienciesId",
                table: "PokemonProficiency");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proficiency",
                table: "Proficiency");

            migrationBuilder.RenameTable(
                name: "Proficiency",
                newName: "Prociciency");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prociciency",
                table: "Prociciency",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonProficiency_Prociciency_ProficienciesId",
                table: "PokemonProficiency",
                column: "ProficienciesId",
                principalTable: "Prociciency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
