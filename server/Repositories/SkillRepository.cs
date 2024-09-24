using PrimalAPI.Helpers;
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
            try
            {
                return _context.Skill.Where(s => s.Id == skillId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }
        }

        public Skill? GetSkillByName(string skillName)
        {
            try
            {
                return _context
                    .Skill.Where(s => s.Name.ToLower() == skillName.ToLower())
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }
        }

        public ICollection<Skill> GetSkills(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            try
            {
                return _context
                    .Skill.OrderBy(s => s.Id)
                    .Skip(skip)
                    .Take(paginationQuery.PageSize)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }
        }

        public int GetSkillCount()
        {
            try
            {
                return _context.Skill.Count();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }
        }

        public ICollection<Skill> GetSkillByPokemonId(int pokemonId)
        {
            try
            {
                return _context.Skill.Where(s => s.Pokemon.Any(p => p.Id == pokemonId)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }
        }

        public ICollection<Skill> GetAllSkills()
        {
            try
            {
                return _context.Skill.OrderBy(s => s.Id).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }
        }
    }
}
