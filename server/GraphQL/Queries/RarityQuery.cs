using PrimalAPI.GraphQL.Dto;
using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class RarityQuery
    {
        [GraphQLDescription("Get a specific rarity by id")]
        public RarityGraphQLDto? GetRarityById(int id, IRarityRepository rarityRepository, [Service] ILogger<RarityQuery> logger)
        {
            logger.LogInformation($"Getting Rarity by Id {id} (GraphQL)");
            var rarity = rarityRepository.GetRarityById(id);
            if (rarity == null)
            {
                logger.LogWarning($"Rarity with Id {id} was not found (GraphQL)");
                return null;
            }
            return new RarityGraphQLDto(id, rarity.Name, rarity.Description);
        }
    }
}
