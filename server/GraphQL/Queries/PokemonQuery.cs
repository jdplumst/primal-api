﻿using PrimalAPI.GraphQL.Dto;
using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class PokemonQuery
    {
        [GraphQLDescription("Get a specific number of random Pokemon from a specific habitat")]
        public ICollection<PokemonGraphQLDto> GetRandomPokemonFromHabitat(
            string habitatName,
            int count,
            IPokemonRepository pokemonRepository,
            [Service] ILogger<PokemonQuery> logger)
        {
            logger.LogInformation($"Getting {count} Random Pokemon from Habitat {habitatName} (GraphQL)");
            var pokemons = pokemonRepository.GetRandomPokemonFromHabitat(habitatName, count);
            var pokemonList = new List<PokemonGraphQLDto>();
            foreach (var pokemon in pokemons)
            {
                pokemonList.Add(new PokemonGraphQLDto(
                    pokemon.Id,
                    pokemon.Name,
                    pokemon.HP,
                    pokemon.Attack,
                    pokemon.SpecialAttack,
                    pokemon.Defense,
                    pokemon.SpecialDefense,
                    pokemon.Speed,
                    pokemon.HatchRate));
            }
            return pokemonList;
        }
    }
}
