using PrimalAPI.Models;
using PrimalAPI.Queries;

namespace PrimalAPI.Interfaces
{
    public interface IHabitatRepository
    {
        Habitat? GetHabitatById(int id);
        Habitat? GetHabitatByName(string name);
        ICollection<Habitat> GetHabitats(PaginationQuery paginationQuery);
        int GetHabitatCount();
        ICollection<Habitat> GetHabitatsByPokemonId(int pokemonId);
        ICollection<Habitat> GetAllHabitats();
    }
}
