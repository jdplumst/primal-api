using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Dto
{
    public class HabitatGraphQLDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
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
