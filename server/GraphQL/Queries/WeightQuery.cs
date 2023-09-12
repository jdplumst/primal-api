using PrimalAPI.GraphQL.Dto;
using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class WeightQuery
    {
        [GraphQLDescription("Get a specific weight class by id")]
        public WeightGraphQLDto? GetWeightById(
            int id,
            IWeightRepository weightRepository,
            [Service] ILogger<WeightQuery> logger)
        {
            logger.LogInformation($"Getting Weight by Id {id} (GraphQL)");
            var weight = weightRepository.GetWeightById(id);
            if (weight == null)
            {
                logger.LogWarning($"Weight with Id {id} was not found (GraphQL)");
                return null;
            }
            return new WeightGraphQLDto(id, weight.Name, weight.Range);
        }

        [GraphQLDescription("Get a specific weight class by name")]
        public WeightGraphQLDto? GetWeightByName(
            string name,
            IWeightRepository weightRepository,
            [Service] ILogger<WeightQuery> logger)
        {
            logger.LogInformation($"Getting Weight by Name {name} (GraphQL)");
            var weight = weightRepository.GetWeightByName(name);
            if (weight == null)
            {
                logger.LogWarning($"Weight with Name {name} was not found (GraphQL)");
                return null;
            }
            return new WeightGraphQLDto(weight.Id, weight.Name, weight.Range);
        }

        [GraphQLDescription("Get a list of all weights")]
        [UsePaging]
        public ICollection<WeightGraphQLDto> GetWeights(
            IWeightRepository weightRepository,
            [Service] ILogger<WeightQuery> logger)
        {
            logger.LogInformation($"Getting all weights (GraphQL)");
            var weights = weightRepository.GetAllWeights();
            var weightList = new List<WeightGraphQLDto>();
            foreach (var weight in weights)
            {
                weightList.Add(new WeightGraphQLDto(weight.Id, weight.Name, weight.Range));
            }
            return weightList;
        }
    }
}
