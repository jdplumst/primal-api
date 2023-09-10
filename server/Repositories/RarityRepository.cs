using PrimalAPI.Interfaces;
using PrimalAPI.Models;

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

        public Rarity? GetRarityByPokemonId(int pokemonId)
        {
            return _context.Rarity.Where(r => r.Pokemon.Any(p => p.Id == pokemonId)).FirstOrDefault();
        }
    }
}
