using PrimalAPI.GraphQL.Dto;
using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class SizeQuery
    {
        public SizeGraphQLDto? GetSizeById(int id, ISizeRepository sizeRepository, [Service] ILogger<SizeQuery> logger)
        {
            logger.LogInformation($"Getting Size by Id {id} (GraphQL)");
            var size = sizeRepository.GetSizeById(id);
            if (size == null)
            {
                logger.LogWarning($"Size with Id {id} was not found (GraphQL)");
                return null;
            }
            return new SizeGraphQLDto(id, size.Name, size.Space);
        }

        public SizeGraphQLDto? GetSizeByName(
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
            return new SizeGraphQLDto(size.Id, size.Name, size.Space);
        }
    }
}
