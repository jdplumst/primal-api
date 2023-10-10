using PrimalAPI.Models;
using PrimalAPI.Queries;

namespace PrimalAPI.Interfaces
{
    public interface ISkillRepository
    {
        Skill? GetSkillById(int skillId);
        Skill? GetSkillByName(string skillName);
        ICollection<Skill> GetSkills(PaginationQuery paginationQuery);
        int GetSkillCount();
        ICollection<Skill> GetSkillByPokemonId(int pokemonId);
        ICollection<Skill> GetAllSkills();
    }
}
