using PrimalAPI.Dto;
using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL
{
    [ExtendObjectType("Query")]
    public class SizeQuery
    {
        public SizeDto? GetSizeById(
            int id,
            ISizeRepository sizeRepository,
            IPokemonRepository pokemonRepository,
            IResourceMaker resourceMaker,
            [Service] ILogger<SizeQuery> logger)
        {
            logger.LogInformation($"Getting Size by Id {id} (GraphQL)");
            var size = sizeRepository.GetSizeById(id);
            if (size == null)
            {
                logger.LogWarning($"Size with Id {id} was not found (GraphQL)");
                return null;
            }
            var pokemon = pokemonRepository.GetPokemonBySizeId(id);
            var pokemonList = resourceMaker.CreatePokemonResources(pokemon);
            return new SizeDto(id, size.Name, size.Space, pokemonList);
        }

        public SizeDto? GetSizeByName(
            string name,
            ISizeRepository sizeRepository,
            IPokemonRepository pokemonRepository,
            IResourceMaker resourceMaker,
            [Service] ILogger<SizeQuery> logger)
        {
            logger.LogInformation($"Getting Size by Name {name} (GraphQL)");
            var size = sizeRepository.GetSizeByName(name);
            if (size == null)
            {
                logger.LogWarning($"Size with Name {name} was not found (GraphQL)");
                return null;
            }
            var pokemon = pokemonRepository.GetPokemonBySizeName(name);
            var pokemonList = resourceMaker.CreatePokemonResources(pokemon);
            return new SizeDto(size.Id, size.Name, size.Space, pokemonList);
        }

    }
}
