using PrimalAPI.GraphQL.Dto;
using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class HabitatQuery
    {
        [GraphQLDescription("Get a specific habitat by id")]
        public HabitatGraphQLDto? GetHabitatById(int id, IHabitatRepository habitatRepository, [Service] ILogger<HabitatQuery> logger)
        {
            logger.LogInformation($"Getting Habitat by Id {id} (GraphQL)");
            var habitat = habitatRepository.GetHabitatById(id);
            if (habitat == null)
            {
                logger.LogWarning($"Habitat with Id {id} was not found (GraphQL)");
                return null;
            }
            return new HabitatGraphQLDto(habitat.Id, habitat.Name, habitat.Description);
        }

        [GraphQLDescription("Get a specific habitat by name")]
        public HabitatGraphQLDto? GetHabitatByName(string name, IHabitatRepository habitatRepository, [Service] ILogger<HabitatQuery> logger)
        {
            logger.LogInformation($"Getting Habitat by Name {name} (GraphQL)");
            var habitat = habitatRepository.GetHabitatByName(name);
            if (habitat == null)
            {
                logger.LogWarning($"Habitat with Name {name} was not found (GraphQL)");
                return null;
            }
            return new HabitatGraphQLDto(habitat.Id, habitat.Name, habitat.Description);
        }

        [GraphQLDescription("Get a list of all habitats")]
        public ICollection<HabitatGraphQLDto> GetHabitats(IHabitatRepository habitatRepository, [Service] ILogger<HabitatQuery> logger)
        {
            logger.LogInformation($"Getting All Habitats (GraphQL)");
            var habitats = habitatRepository.GetAllHabitats();
            var habitatList = new List<HabitatGraphQLDto>();
            foreach (var habitat in habitats)
            {
                habitatList.Add(new HabitatGraphQLDto(habitat.Id, habitat.Name, habitat.Description));
            }
            return habitatList;
        }
    }
}
