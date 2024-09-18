using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Dto
{
    [GraphQLName("Size")]
    [GraphQLDescription(
        "Use Pokémon sizes to determine how feasible it is "
            + "for a Pokémon to be moving together with you through halls, tight "
            + "caves, or while just walking down the street together"
    )]
    public class SizeGraphQLDto
    {
        [GraphQLDescription("The id of the size")]
        public int Id { get; set; }

        [GraphQLDescription("The name of the size")]
        public string Name { get; set; }

        [GraphQLDescription("The amount of space that Pokemon of this size take up")]
        public string Space { get; set; }

        [GraphQLDescription("A list of the Pokemon of this size")]
        public ICollection<PokemonGraphQLDto> GetPokemon(
            [Parent] SizeGraphQLDto size,
            IPokemonRepository pokemonRepository
        )
        {
            var pokemons = pokemonRepository.GetPokemonBySizeId(size.Id);
            var pokemonList = new List<PokemonGraphQLDto>();
            foreach (var pokemon in pokemons)
            {
                pokemonList.Add(
                    new PokemonGraphQLDto(
                        pokemon.Id,
                        pokemon.Name,
                        pokemon.HP,
                        pokemon.Attack,
                        pokemon.SpecialAttack,
                        pokemon.Defense,
                        pokemon.SpecialDefense,
                        pokemon.Speed,
                        pokemon.HatchRate
                    )
                );
            }
            return pokemonList;
        }

        public SizeGraphQLDto(int id, string name, string space)
        {
            Id = id;
            Name = name;
            Space = space;
        }
    }
}
