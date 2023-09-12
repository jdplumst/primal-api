using PrimalAPI.Models;
using PrimalAPI.Queries;

namespace PrimalAPI.Interfaces
{
    public interface IEggGroupRepository
    {
        EggGroup? GetEggGroupById(int eggGroupId);
        EggGroup? GetEggGroupByName(string eggGroupName);
        ICollection<EggGroup> GetEggGroups(PaginationQuery paginationQuery);
        int GetEggGroupCount();
        ICollection<EggGroup> GetEggGroupByPokemonId(int pokemonId);
        ICollection<EggGroup> GetAllEggGroups();
    }
}
