using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class LinkPokemonAndRarity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RarityId",
                table: "Pokemon",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_RarityId",
                table: "Pokemon",
                column: "RarityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Rarity_RarityId",
                table: "Pokemon",
                column: "RarityId",
                principalTable: "Rarity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Rarity_RarityId",
                table: "Pokemon");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_RarityId",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "RarityId",
                table: "Pokemon");
        }
    }
}
