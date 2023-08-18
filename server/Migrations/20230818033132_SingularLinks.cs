using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class SingularLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietPokemon_Diet_DietsId",
                table: "DietPokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_EggGroupPokemon_EggGroup_EggGroupsId",
                table: "EggGroupPokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitatPokemon_Habitat_HabitatsId",
                table: "HabitatPokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_MovePokemon_Move_MovesId",
                table: "MovePokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_MoveProficiency_Move_MovesId",
                table: "MoveProficiency");

            migrationBuilder.DropForeignKey(
                name: "FK_MoveProficiency_Proficiency_ProficienciesId",
                table: "MoveProficiency");

            migrationBuilder.DropForeignKey(
                name: "FK_PassivePokemon_Passive_PassivesId",
                table: "PassivePokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonProficiency_Proficiency_ProficienciesId",
                table: "PokemonProficiency");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonSkill_Skill_SkillsId",
                table: "PokemonSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonType_Type_TypesId",
                table: "PokemonType");

            migrationBuilder.RenameColumn(
                name: "TypesId",
                table: "PokemonType",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonType_TypesId",
                table: "PokemonType",
                newName: "IX_PokemonType_TypeId");

            migrationBuilder.RenameColumn(
                name: "SkillsId",
                table: "PokemonSkill",
                newName: "SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonSkill_SkillsId",
                table: "PokemonSkill",
                newName: "IX_PokemonSkill_SkillId");

            migrationBuilder.RenameColumn(
                name: "ProficienciesId",
                table: "PokemonProficiency",
                newName: "ProficiencieId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonProficiency_ProficienciesId",
                table: "PokemonProficiency",
                newName: "IX_PokemonProficiency_ProficiencieId");

            migrationBuilder.RenameColumn(
                name: "PassivesId",
                table: "PassivePokemon",
                newName: "PassiveId");

            migrationBuilder.RenameColumn(
                name: "ProficienciesId",
                table: "MoveProficiency",
                newName: "ProficiencyId");

            migrationBuilder.RenameColumn(
                name: "MovesId",
                table: "MoveProficiency",
                newName: "MoveId");

            migrationBuilder.RenameIndex(
                name: "IX_MoveProficiency_ProficienciesId",
                table: "MoveProficiency",
                newName: "IX_MoveProficiency_ProficiencyId");

            migrationBuilder.RenameColumn(
                name: "MovesId",
                table: "MovePokemon",
                newName: "MoveId");

            migrationBuilder.RenameColumn(
                name: "HabitatsId",
                table: "HabitatPokemon",
                newName: "HabitatId");

            migrationBuilder.RenameColumn(
                name: "EggGroupsId",
                table: "EggGroupPokemon",
                newName: "EggGroupId");

            migrationBuilder.RenameColumn(
                name: "DietsId",
                table: "DietPokemon",
                newName: "DietId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietPokemon_Diet_DietId",
                table: "DietPokemon",
                column: "DietId",
                principalTable: "Diet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EggGroupPokemon_EggGroup_EggGroupId",
                table: "EggGroupPokemon",
                column: "EggGroupId",
                principalTable: "EggGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HabitatPokemon_Habitat_HabitatId",
                table: "HabitatPokemon",
                column: "HabitatId",
                principalTable: "Habitat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovePokemon_Move_MoveId",
                table: "MovePokemon",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoveProficiency_Move_MoveId",
                table: "MoveProficiency",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoveProficiency_Proficiency_ProficiencyId",
                table: "MoveProficiency",
                column: "ProficiencyId",
                principalTable: "Proficiency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassivePokemon_Passive_PassiveId",
                table: "PassivePokemon",
                column: "PassiveId",
                principalTable: "Passive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonProficiency_Proficiency_ProficiencieId",
                table: "PokemonProficiency",
                column: "ProficiencieId",
                principalTable: "Proficiency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonSkill_Skill_SkillId",
                table: "PokemonSkill",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonType_Type_TypeId",
                table: "PokemonType",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietPokemon_Diet_DietId",
                table: "DietPokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_EggGroupPokemon_EggGroup_EggGroupId",
                table: "EggGroupPokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitatPokemon_Habitat_HabitatId",
                table: "HabitatPokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_MovePokemon_Move_MoveId",
                table: "MovePokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_MoveProficiency_Move_MoveId",
                table: "MoveProficiency");

            migrationBuilder.DropForeignKey(
                name: "FK_MoveProficiency_Proficiency_ProficiencyId",
                table: "MoveProficiency");

            migrationBuilder.DropForeignKey(
                name: "FK_PassivePokemon_Passive_PassiveId",
                table: "PassivePokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonProficiency_Proficiency_ProficiencieId",
                table: "PokemonProficiency");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonSkill_Skill_SkillId",
                table: "PokemonSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonType_Type_TypeId",
                table: "PokemonType");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "PokemonType",
                newName: "TypesId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonType_TypeId",
                table: "PokemonType",
                newName: "IX_PokemonType_TypesId");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "PokemonSkill",
                newName: "SkillsId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonSkill_SkillId",
                table: "PokemonSkill",
                newName: "IX_PokemonSkill_SkillsId");

            migrationBuilder.RenameColumn(
                name: "ProficiencieId",
                table: "PokemonProficiency",
                newName: "ProficienciesId");

            migrationBuilder.RenameIndex(
                name: "IX_PokemonProficiency_ProficiencieId",
                table: "PokemonProficiency",
                newName: "IX_PokemonProficiency_ProficienciesId");

            migrationBuilder.RenameColumn(
                name: "PassiveId",
                table: "PassivePokemon",
                newName: "PassivesId");

            migrationBuilder.RenameColumn(
                name: "ProficiencyId",
                table: "MoveProficiency",
                newName: "ProficienciesId");

            migrationBuilder.RenameColumn(
                name: "MoveId",
                table: "MoveProficiency",
                newName: "MovesId");

            migrationBuilder.RenameIndex(
                name: "IX_MoveProficiency_ProficiencyId",
                table: "MoveProficiency",
                newName: "IX_MoveProficiency_ProficienciesId");

            migrationBuilder.RenameColumn(
                name: "MoveId",
                table: "MovePokemon",
                newName: "MovesId");

            migrationBuilder.RenameColumn(
                name: "HabitatId",
                table: "HabitatPokemon",
                newName: "HabitatsId");

            migrationBuilder.RenameColumn(
                name: "EggGroupId",
                table: "EggGroupPokemon",
                newName: "EggGroupsId");

            migrationBuilder.RenameColumn(
                name: "DietId",
                table: "DietPokemon",
                newName: "DietsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietPokemon_Diet_DietsId",
                table: "DietPokemon",
                column: "DietsId",
                principalTable: "Diet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EggGroupPokemon_EggGroup_EggGroupsId",
                table: "EggGroupPokemon",
                column: "EggGroupsId",
                principalTable: "EggGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HabitatPokemon_Habitat_HabitatsId",
                table: "HabitatPokemon",
                column: "HabitatsId",
                principalTable: "Habitat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovePokemon_Move_MovesId",
                table: "MovePokemon",
                column: "MovesId",
                principalTable: "Move",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoveProficiency_Move_MovesId",
                table: "MoveProficiency",
                column: "MovesId",
                principalTable: "Move",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoveProficiency_Proficiency_ProficienciesId",
                table: "MoveProficiency",
                column: "ProficienciesId",
                principalTable: "Proficiency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassivePokemon_Passive_PassivesId",
                table: "PassivePokemon",
                column: "PassivesId",
                principalTable: "Passive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonProficiency_Proficiency_ProficienciesId",
                table: "PokemonProficiency",
                column: "ProficienciesId",
                principalTable: "Proficiency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonSkill_Skill_SkillsId",
                table: "PokemonSkill",
                column: "SkillsId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonType_Type_TypesId",
                table: "PokemonType",
                column: "TypesId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
