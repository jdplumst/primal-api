using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Dto
{
    public class SizeGraphQLDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Space { get; set; }
        public ICollection<PokemonGraphQLDto> GetPokemon([Parent] SizeGraphQLDto size, IPokemonRepository pokemonRepository)
        {
            var pokemons = pokemonRepository.GetPokemonBySizeId(size.Id);
            var pokemonList = new List<PokemonGraphQLDto>();
            foreach (var pokemon in pokemons)
            {
                pokemonList.Add(new PokemonGraphQLDto(pokemon.Id, pokemon.Name, pokemon.HP, pokemon.Attack, pokemon.SpecialAttack, pokemon.Defense, pokemon.SpecialDefense, pokemon.Speed, pokemon.HatchRate));
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
