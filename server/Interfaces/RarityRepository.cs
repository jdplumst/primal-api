using PrimalAPI.Models;

namespace PrimalAPI.Interfaces
{
    public interface RarityRepository
    {
        Rarity? GetRarityById(int rarityId);
    }
}
