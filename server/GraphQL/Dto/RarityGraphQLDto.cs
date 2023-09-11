using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Dto
{
    [GraphQLName("Rarity")]
    [GraphQLDescription("Pokémon are not equal in population, some Pokémon mass produce to try and survive predation, while others just live in large families that work together. Others never stray from comfort while others commonly swarm town marketplaces.")]
    public class RarityGraphQLDto
    {
        [GraphQLDescription("The id of the rarity")]
        public int Id { get; set; }

        [GraphQLDescription("The name of the rarity")]
        public string Name { get; set; }

        [GraphQLDescription("A description of the rarity")]
        public string Description { get; set; }

        [GraphQLDescription("A list of Pokemon with this rarity")]
        public ICollection<PokemonGraphQLDto> GetPokemon([Parent] RarityGraphQLDto rarity, IPokemonRepository pokemonRepository)
        {
            var pokemons = pokemonRepository.GetPokemonByRarityId(rarity.Id);
            var pokemonList = new List<PokemonGraphQLDto>();
            foreach (var pokemon in pokemons)
            {
                pokemonList.Add(new PokemonGraphQLDto(pokemon.Id, pokemon.Name, pokemon.HP, pokemon.Attack, pokemon.SpecialAttack, pokemon.Defense, pokemon.SpecialDefense, pokemon.Speed, pokemon.HatchRate));
            }
            return pokemonList;
        }

        public RarityGraphQLDto(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
