using server.Dto;
using server.Models;

namespace server.Interfaces
{
    public interface IResourceMaker
    {
        ICollection<ResourceDto> CreatePokemonResources(ICollection<Pokemon> pokemons);
    }
}
