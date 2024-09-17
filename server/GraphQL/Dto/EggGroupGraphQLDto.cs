using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Dto
{
    [GraphQLName("EggGroup")]
    [GraphQLDescription("Pokémon can only produce eggs when opposite genders " +
        "mate and both Pokémon share an egg group.")]
    public class EggGroupGraphQLDto
    {
        [GraphQLDescription("The id of the egg group")]
        public int Id { get; set; }

        [GraphQLDescription("The name of the egg group")]
        public string Name { get; set; }

        [GraphQLDescription("A list of Pokemon belonging to this egg group")]
        public ICollection<PokemonGraphQLDto> GetPokemon(
            [Parent] EggGroupGraphQLDto eggGroup,
            IPokemonRepository pokemonRepository)
        {
            var pokemons = pokemonRepository.GetPokemonByEggGroupId(eggGroup.Id);
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

        public EggGroupGraphQLDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
