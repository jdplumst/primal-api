using PrimalAPI.Interfaces;
using PrimalAPI.Models;
using PrimalAPI.Queries;

namespace PrimalAPI.Repositories
{
    public class EggGroupRepository : IEggGroupRepository
    {
        private readonly DataContext _context;

        public EggGroupRepository(DataContext context)
        {
            _context = context;
        }

        public EggGroup? GetEggGroupById(int eggGroupId)
        {
            return _context.EggGroup.Where(e => e.Id == eggGroupId).FirstOrDefault();
        }

        public EggGroup? GetEggGroupByName(string eggGroupName)
        {
            return _context.EggGroup.Where(e => e.Name.ToLower() == eggGroupName.ToLower()).FirstOrDefault();
        }

        public ICollection<EggGroup> GetEggGroups(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return _context.EggGroup.OrderBy(e => e.Id).Skip(skip).Take(paginationQuery.PageSize).ToList();
        }

        public int GetEggGroupCount()
        {
            return _context.EggGroup.Count();
        }

        public ICollection<EggGroup> GetEggGroupByPokemonId(int pokemonId)
        {
            return _context.EggGroup.Where(e => e.Pokemon.Any(p => p.Id == pokemonId)).ToList();
        }

        public ICollection<EggGroup> GetAllEggGroups()
        {
            return _context.EggGroup.OrderBy(e => e.Id).ToList();
        }
    }
}
