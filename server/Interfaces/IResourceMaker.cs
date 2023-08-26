using PrimalAPI.Dto;
using PrimalAPI.Models;

namespace PrimalAPI.Interfaces
{
    public interface IResourceMaker
    {
        ICollection<ResourceDto> CreatePokemonResources(ICollection<Pokemon> pokemons);
    }
}
