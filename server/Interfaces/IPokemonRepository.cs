using PrimalAPI.Models;

namespace PrimalAPI.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemonBySizeId(int sizeId);
        ICollection<Pokemon> GetPokemonBySizeName(string name);
        ICollection<Pokemon> GetPokemonByHabitatId(int habitatId);
        ICollection<Pokemon> GetPokemonByHabitatName(string name);
        ICollection<Pokemon> GetPokemonByWeightId(int weightId);
        ICollection<Pokemon> GetPokemonByWeightName(string weightName);
        ICollection<Pokemon> GetPokemonByRarityId(int rarityId);
        ICollection<Pokemon> GetPokemonByEggGroupId(int eggGroupId);
        ICollection<Pokemon> GetRandomPokemonFromHabitat(string habitatName, int count);
    }
}
