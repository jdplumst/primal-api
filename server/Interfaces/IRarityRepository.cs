using PrimalAPI.Models;
using PrimalAPI.Queries;

namespace PrimalAPI.Interfaces
{
    public interface IRarityRepository
    {
        Rarity? GetRarityById(int rarityId);
        Rarity? GetRarityByName(string rarityName);
        ICollection<Rarity> GetRarities(PaginationQuery paginationQuery);
        int GetRarityCount();
        Rarity? GetRarityByPokemonId(int pokemonId);
        ICollection<Rarity> GetAllRarities();
    }
}
