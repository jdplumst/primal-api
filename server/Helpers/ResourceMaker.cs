using PrimalAPI.Dto;
using PrimalAPI.Interfaces;
using PrimalAPI.Models;

namespace PrimalAPI.Helpers
{
    public class ResourceMaker : IResourceMaker
    {
        public ICollection<ResourceDto> CreatePokemonResources(ICollection<Pokemon> pokemons)
        {
            var resources = new List<ResourceDto>();
            foreach (var pokemon in pokemons)
            {
                var url = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
                  ? Environment.GetEnvironmentVariable("DEV_SERVER_URL") + "/pokemon/" + pokemon.Id
                  : Environment.GetEnvironmentVariable("PROD_SERVER_URL") + "/pokemon/" + pokemon.Id;
                resources.Add(new ResourceDto(pokemon.Name, url));
            }

            return resources;
        }
    }
}
