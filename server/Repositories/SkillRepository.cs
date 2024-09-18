using PrimalAPI.Interfaces;
using PrimalAPI.Models;
using PrimalAPI.Queries;

namespace PrimalAPI.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DataContext _context;

        public SkillRepository(DataContext context)
        {
            _context = context;
        }

        public Skill? GetSkillById(int skillId)
        {
            return _context.Skill.Where(s => s.Id == skillId).FirstOrDefault();
        }

        public Skill? GetSkillByName(string skillName)
        {
            return _context
                .Skill.Where(s => s.Name.ToLower() == skillName.ToLower())
                .FirstOrDefault();
        }

        public ICollection<Skill> GetSkills(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return _context
                .Skill.OrderBy(s => s.Id)
                .Skip(skip)
                .Take(paginationQuery.PageSize)
                .ToList();
        }

        public int GetSkillCount()
        {
            return _context.Skill.Count();
        }

        public ICollection<Skill> GetSkillByPokemonId(int pokemonId)
        {
            return _context.Skill.Where(s => s.Pokemon.Any(p => p.Id == pokemonId)).ToList();
        }

        public ICollection<Skill> GetAllSkills()
        {
            return _context.Skill.OrderBy(s => s.Id).ToList();
        }
    }
}
