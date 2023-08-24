using server.Models;

namespace server.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemonBySize(int sizeId);
        ICollection<Pokemon> GetPokemonByHabitat(int habitatId);
    }
}
