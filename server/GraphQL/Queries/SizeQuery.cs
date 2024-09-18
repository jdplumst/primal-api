using PrimalAPI.GraphQL.Dto;
using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class SizeQuery
    {
        [GraphQLDescription("Get a specific size by id")]
        public SizeGraphQLDto? GetSizeById(
            int id,
            ISizeRepository sizeRepository,
            [Service] ILogger<SizeQuery> logger
        )
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

        [GraphQLDescription("Get a specific size by name")]
        public SizeGraphQLDto? GetSizeByName(
            string name,
            ISizeRepository sizeRepository,
            [Service] ILogger<SizeQuery> logger
        )
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

        [GraphQLDescription("Get a list of all sizes")]
        [UsePaging]
        public ICollection<SizeGraphQLDto> GetSizes(
            ISizeRepository sizeRepository,
            [Service] ILogger<SizeQuery> logger
        )
        {
            logger.LogInformation($"Getting all sizes (GraphQL)");
            var sizes = sizeRepository.GetAllSizes();
            var sizeList = new List<SizeGraphQLDto>();
            foreach (var size in sizes)
            {
                sizeList.Add(new SizeGraphQLDto(size.Id, size.Name, size.Space));
            }
            return sizeList;
        }
    }
}
