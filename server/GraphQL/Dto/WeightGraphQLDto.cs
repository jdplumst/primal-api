using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Dto
{
    [GraphQLName("Weight")]
    [GraphQLDescription("Weight Classes are used to figure out their general bur-den on a person who might be carrying them, or a build-ing’s floor, a bridge, a boat, a plane, or anything really that’s holding something else up.")]
    public class WeightGraphQLDto
    {
        [GraphQLDescription("The id of the weight class")]
        public int Id { get; set; }

        [GraphQLDescription("The name of the weight class")]
        public string Name { get; set; }

        [GraphQLDescription("The weight range of this weight class")]
        public string Range { get; set; }

        [GraphQLDescription("A list of Pokemon belonging to this weight class")]
        public ICollection<PokemonGraphQLDto> GetPokemon([Parent] WeightGraphQLDto weight, IPokemonRepository pokemonRepository)
        {
            var pokemons = pokemonRepository.GetPokemonByWeightId(weight.Id);
            var pokemonList = new List<PokemonGraphQLDto>();
            foreach (var pokemon in pokemons)
            {
                pokemonList.Add(new PokemonGraphQLDto(pokemon.Id, pokemon.Name, pokemon.HP, pokemon.Attack, pokemon.SpecialAttack, pokemon.Defense, pokemon.SpecialDefense, pokemon.Speed, pokemon.HatchRate));
            }
            return pokemonList;
        }

        public WeightGraphQLDto(int id, string name, string range)
        {
            Id = id;
            Name = name;
            Range = range;
        }
    }
}
