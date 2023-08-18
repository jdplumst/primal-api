using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class LinkMoveAndProficiency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoveProficiency",
                columns: table => new
                {
                    MovesId = table.Column<int>(type: "integer", nullable: false),
                    ProficienciesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveProficiency", x => new { x.MovesId, x.ProficienciesId });
                    table.ForeignKey(
                        name: "FK_MoveProficiency_Move_MovesId",
                        column: x => x.MovesId,
                        principalTable: "Move",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoveProficiency_Proficiency_ProficienciesId",
                        column: x => x.ProficienciesId,
                        principalTable: "Proficiency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoveProficiency_ProficienciesId",
                table: "MoveProficiency",
                column: "ProficienciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoveProficiency");
        }
    }
}
