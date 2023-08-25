using server.Models;

namespace server.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemonBySize(int sizeId);
        ICollection<Pokemon> GetPokemonByHabitatId(int habitatId);
        ICollection<Pokemon> GetPokemonByHabitatName(string name);
    }
}
