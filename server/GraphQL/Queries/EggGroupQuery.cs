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

        [GraphQLDescription("Get a specific egg group by name")]
        public EggGroupGraphQLDto? GetEggGroupByName(
            string name,
            IEggGroupRepository eggGroupRepository,
            [Service] ILogger<EggGroupQuery> logger)
        {
            logger.LogInformation($"Getting Egg Group by Name {name} (GraphQL)");
            var eggGroup = eggGroupRepository.GetEggGroupByName(name);
            if (eggGroup == null)
            {
                logger.LogWarning($"Egg Group with Name {name} was not found (GraphQL)");
                return null;
            }
            return new EggGroupGraphQLDto(eggGroup.Id, eggGroup.Name);
        }

        [GraphQLDescription("Get a list of all egg groups")]
        [UsePaging]
        public ICollection<EggGroupGraphQLDto> GetEggGroups(
            IEggGroupRepository eggGroupRepository,
            [Service] ILogger<EggGroupQuery> logger)
        {
            logger.LogInformation($"Getting All Egg Groups (GraphQL)");
            var eggGroups = eggGroupRepository.GetAllEggGroups();
            var eggGroupList = new List<EggGroupGraphQLDto>();
            foreach (var eggGroup in eggGroups)
            {
                eggGroupList.Add(new EggGroupGraphQLDto(eggGroup.Id, eggGroup.Name));
            }
            return eggGroupList;
        }
    }
}
