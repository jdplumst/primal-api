using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PrimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRarity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonProficiency_Proficiency_ProficiencieId",
                table: "PokemonProficiency");

            migrationBuilder.RenameColumn(
                name: "ProficiencieId",
                table: "PokemonProficiency",
                newName: "ProficiencyId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonProficiency_ProficiencieId",
                table: "PokemonProficiency",
                newName: "IX_PokemonProficiency_ProficiencyId");

            migrationBuilder.CreateTable(
                name: "Rarity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarity", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonProficiency_Proficiency_ProficiencyId",
                table: "PokemonProficiency",
                column: "ProficiencyId",
                principalTable: "Proficiency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonProficiency_Proficiency_ProficiencyId",
                table: "PokemonProficiency");

            migrationBuilder.DropTable(
                name: "Rarity");

            migrationBuilder.RenameColumn(
                name: "ProficiencyId",
                table: "PokemonProficiency",
                newName: "ProficiencieId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonProficiency_ProficiencyId",
                table: "PokemonProficiency",
                newName: "IX_PokemonProficiency_ProficiencieId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonProficiency_Proficiency_ProficiencieId",
                table: "PokemonProficiency",
                column: "ProficiencieId",
                principalTable: "Proficiency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
