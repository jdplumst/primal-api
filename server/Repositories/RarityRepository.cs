using PrimalAPI.Interfaces;
using PrimalAPI.Models;
using PrimalAPI.Queries;

namespace PrimalAPI.Repositories
{
    public class RarityRepository : IRarityRepository
    {
        private readonly DataContext _context;

        public RarityRepository(DataContext context) { _context = context; }

        public Rarity? GetRarityById(int rarityId)
        {
            return _context.Rarity.Where(r => r.Id == rarityId).FirstOrDefault();
        }

        public Rarity? GetRarityByName(string rarityName)
        {
            return _context.Rarity.Where(r => r.Name.ToLower() == rarityName.ToLower()).FirstOrDefault();
        }

        public ICollection<Rarity> GetRarities(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return _context.Rarity.OrderBy(r => r.Id).Skip(skip).Take(paginationQuery.PageSize).ToList();
        }

        public int GetRarityCount()
        {
            return _context.Rarity.Count();
        }

        public Rarity? GetRarityByPokemonId(int pokemonId)
        {
            return _context.Rarity.Where(r => r.Pokemon.Any(p => p.Id == pokemonId)).FirstOrDefault();
        }

        public ICollection<Rarity> GetAllRarities()
        {
            return _context.Rarity.OrderBy(r => r.Id).ToList();
        }
    }
}
