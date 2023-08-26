using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeysToSizeAndWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_SizeId",
                table: "Pokemon",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_WeightId",
                table: "Pokemon",
                column: "WeightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Size_SizeId",
                table: "Pokemon",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Weight_WeightId",
                table: "Pokemon",
                column: "WeightId",
                principalTable: "Weight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Size_SizeId",
                table: "Pokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Weight_WeightId",
                table: "Pokemon");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_SizeId",
                table: "Pokemon");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_WeightId",
                table: "Pokemon");
        }
    }
}
