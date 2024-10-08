﻿using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Dto
{
    [GraphQLName("Pokemon")]
    [GraphQLDescription("Pokemon are creatures that inhabit the world of the game")]
    public class PokemonGraphQLDto
    {
        [GraphQLDescription("The id of the Pokemon")]
        public int Id { get; set; }

        [GraphQLDescription("The name of the Pokemon")]
        public string Name { get; set; }

        [GraphQLDescription("The HP stat of the Pokemon")]
        public int HP { get; set; }

        [GraphQLDescription("The attack stat of the Pokemon")]
        public int Attack { get; set; }

        [GraphQLDescription("The special attack stat of the Pokemon")]
        public int SpecialAttack { get; set; }

        [GraphQLDescription("The defense stat of the Pokemon")]
        public int Defense { get; set; }

        [GraphQLDescription("The special defense stat of the Pokemon")]
        public int SpecialDefense { get; set; }

        [GraphQLDescription("The speed stat of the Pokemon")]
        public int Speed { get; set; }

        //public ICollection<Type> Type { get; set; }

        [GraphQLDescription("The size of the Pokemon")]
        public SizeGraphQLDto GetSize(
            [Parent] PokemonGraphQLDto pokemon,
            ISizeRepository sizeRepository
        )
        {
            var size = sizeRepository.GetSizeByPokemonId(pokemon.Id);
            return new SizeGraphQLDto(size!.Id, size.Name, size.Space);
        }

        [GraphQLDescription("The weight class of the Pokemon")]
        public WeightGraphQLDto GetWeight(
            [Parent] PokemonGraphQLDto pokemon,
            IWeightRepository weightRepository
        )
        {
            var weight = weightRepository.GetWeightByPokemonId(pokemon.Id);
            return new WeightGraphQLDto(weight!.Id, weight.Name, weight.Range);
        }

        [GraphQLDescription("A list of the egg groups of this Pokemon")]
        public ICollection<EggGroupGraphQLDto> GetEggGroups(
            [Parent] PokemonGraphQLDto pokemon,
            IEggGroupRepository eggGroupRepository
        )
        {
            var eggGroups = eggGroupRepository.GetEggGroupByPokemonId(pokemon.Id);
            var eggGroupList = new List<EggGroupGraphQLDto>();
            foreach (var eggGroup in eggGroups)
            {
                eggGroupList.Add(new EggGroupGraphQLDto(eggGroup.Id, eggGroup.Name));
            }
            return eggGroupList;
        }

        [GraphQLDescription("The amount of time it takes this Pokemon to hatch from an egg")]
        public string HatchRate { get; set; }

        //public ICollection<Diet> Diet { get; set; }

        [GraphQLDescription("A list of habitats that this Pokemon can be found in")]
        public ICollection<HabitatGraphQLDto> GetHabitats(
            [Parent] PokemonGraphQLDto pokemon,
            IHabitatRepository habitatRepository
        )
        {
            var habitats = habitatRepository.GetHabitatsByPokemonId(pokemon.Id);
            var habitatList = new List<HabitatGraphQLDto>();
            foreach (var habitat in habitats)
            {
                habitatList.Add(
                    new HabitatGraphQLDto(habitat.Id, habitat.Name, habitat.Description)
                );
            }
            return habitatList;
        }

        //public ICollection<Proficiency> Proficiency { get; set; }

        //public ICollection<Skill> Skill { get; set; }

        //public ICollection<Passive> Passive { get; set; }

        //public ICollection<Move> Move { get; set; }

        [GraphQLDescription("The rarity of the Pokemon")]
        public RarityGraphQLDto GetRarity(
            [Parent] PokemonGraphQLDto pokemon,
            IRarityRepository rarityRepository
        )
        {
            var rarity = rarityRepository.GetRarityByPokemonId(pokemon.Id);
            return new RarityGraphQLDto(rarity!.Id, rarity.Name, rarity.Description);
        }

        public PokemonGraphQLDto(
            int id,
            string name,
            int hp,
            int attack,
            int specialAttack,
            int defense,
            int specialDefense,
            int speed,
            string hatchRate
        )
        {
            Id = id;
            Name = name;
            HP = hp;
            Attack = attack;
            SpecialAttack = specialAttack;
            Defense = defense;
            SpecialDefense = specialDefense;
            Speed = speed;
            HatchRate = hatchRate;
        }
    }
}
