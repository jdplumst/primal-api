using PrimalAPI.GraphQL.Dto;
using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class EggGroupQuery
    {
        [GraphQLDescription("Get a specific egg group by id")]
        public EggGroupGraphQLDto? GetEggGroupById(
            int id,
            IEggGroupRepository eggGroupRepository,
            [Service] ILogger<EggGroupQuery> logger)
        {
            logger.LogInformation($"Getting Egg Group by Id {id} (GraphQL)");
            var eggGroup = eggGroupRepository.GetEggGroupById(id);
            if (eggGroup == null)
            {
                logger.LogWarning($"Egg Group with Id {id} was not found (GraphQL)");
                return null;
            }
            return new EggGroupGraphQLDto(eggGroup.Id, eggGroup.Name);
        }
    }
}
