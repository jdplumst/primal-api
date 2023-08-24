using server.Dto;
using server.Interfaces;
using server.Models;

namespace server.Helpers
{
    public class ResourceMaker : IResourceMaker
    {
        public ResourceDto CreatePokemonResource(Pokemon pokemon)
        {
            var url = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
                  ? Environment.GetEnvironmentVariable("DEV_SERVER_URL") + "/pokemon/" + pokemon.Id
                  : Environment.GetEnvironmentVariable("PROD_SERVER_URL") + "/pokemon/" + pokemon.Id;
            return new ResourceDto(pokemon.Name, url);
        }
    }
}
