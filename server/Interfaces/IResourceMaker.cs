using server.Dto;
using server.Models;

namespace server.Interfaces
{
    public interface IResourceMaker
    {
        ResourceDto CreatePokemonResource(Pokemon pokemon);
    }
}
