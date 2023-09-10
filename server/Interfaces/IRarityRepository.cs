using PrimalAPI.Models;

namespace PrimalAPI.Interfaces
{
    public interface IRarityRepository
    {
        Rarity? GetRarityById(int rarityId);
        Rarity? GetRarityByPokemonId(int pokemonId);
    }
}
