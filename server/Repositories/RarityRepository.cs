using PrimalAPI.Models;

namespace PrimalAPI.Repositories
{
    public class RarityRepository
    {
        private readonly DataContext _context;

        public RarityRepository(DataContext context) { _context = context; }
        public Rarity? GetRarityById(int rarityId)
        {
            return _context.Rarity.Where(r => r.Id == rarityId).FirstOrDefault();
        }
    }
}
