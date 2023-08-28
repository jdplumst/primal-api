using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Dto
{
    [GraphQLDescription("The habitat entry explains what kind of terrain to look for if you intend to hunt for a particular species of Pokémon")]
    public class HabitatGraphQLDto
    {
        [GraphQLDescription("The id of the habitat")]
        public int Id { get; set; }
        [GraphQLDescription("The name of the habitat")]
        public string Name { get; set; }
        [GraphQLDescription("A description of the habitat")]
        public string Description { get; set; }
        [GraphQLDescription("A list of Pokemon that can be found in this habitat")]
        public ICollection<PokemonGraphQLDto> GetPokemon([Parent] HabitatGraphQLDto habitat, IPokemonRepository pokemonRepository)
        {
            var pokemons = pokemonRepository.GetPokemonByHabitatId(habitat.Id);
            var pokemonList = new List<PokemonGraphQLDto>();
            foreach (var pokemon in pokemons)
            {
                pokemonList.Add(new PokemonGraphQLDto(pokemon.Id, pokemon.Name, pokemon.HP, pokemon.Attack, pokemon.SpecialAttack, pokemon.Defense, pokemon.SpecialDefense, pokemon.Speed, pokemon.HatchRate));
            }
            return pokemonList;
        }

        public HabitatGraphQLDto(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
