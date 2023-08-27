﻿using PrimalAPI.GraphQL.Dto;
using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class HabitatQuery
    {
        public HabitatGraphQLDto? GetHabitatById(int id, IHabitatRepository habitatRepository, [Service] ILogger<HabitatQuery> logger)
        {
            logger.LogInformation($"Getting Habitat by Id {id} (GraphQL)");
            var habitat = habitatRepository.GetHabitatById(id);
            if (habitat == null)
            {
                logger.LogWarning($"Size with Id {id} was not found (GraphQL)");
                return null;
            }
            return new HabitatGraphQLDto(habitat.Id, habitat.Name, habitat.Description);
        }

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
