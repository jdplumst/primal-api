using PrimalAPI.Models;

namespace PrimalAPI.Interfaces
{
    public interface IRarityRepository
    {
        Rarity? GetRarityById(int rarityId);
        Rarity? GetRarityByName(string rarityName);
        Rarity? GetRarityByPokemonId(int pokemonId);
        ICollection<Rarity> GetAllRarities();
    }
}
