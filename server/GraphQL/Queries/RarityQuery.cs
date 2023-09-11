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

        [GraphQLDescription("Get a specific rarity by name")]
        public RarityGraphQLDto? GetRarityByName(string name, IRarityRepository rarityRepository, [Service] ILogger<RarityQuery> logger)
        {
            logger.LogInformation($"Getting Rarity by Name {name} (GraphQL)");
            var rarity = rarityRepository.GetRarityByName(name);
            if (rarity == null)
            {
                logger.LogWarning($"Rarity with Name {name} was not found (GraphQL)");
                return null;
            }
            return new RarityGraphQLDto(rarity.Id, rarity.Name, rarity.Description);
        }

        [GraphQLDescription("Get a list of all rarities")]
        [UsePaging]
        public ICollection<RarityGraphQLDto> GetRarities(IRarityRepository rarityRepository, [Service] ILogger<RarityQuery> logger)
        {
            logger.LogInformation($"Getting All Rarities (GraphQL)");
            var rarities = rarityRepository.GetAllRarities();
            var rarityList = new List<RarityGraphQLDto>();
            foreach (var rarity in rarities)
            {
                rarityList.Add(new RarityGraphQLDto(rarity.Id, rarity.Name, rarity.Description));
            }
            return rarityList;
        }
    }
}
