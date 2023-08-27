using PrimalAPI.Interfaces;

namespace PrimalAPI.GraphQL.Dto
{
    public class PokemonGraphQLDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int SpecialAttack { get; set; }
        public int Defense { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        //public ICollection<Type> Type { get; set; }
        public SizeGraphQLDto GetSize([Parent] PokemonGraphQLDto pokemon, ISizeRepository sizeRepository)
        {
            var size = sizeRepository.GetSizeByPokemonId(pokemon.Id);
            return new SizeGraphQLDto(size.Id, size.Name, size.Space);
        }
        //public int WeightId { get; set; }
        //public ICollection<EggGroup> EggGroup { get; set; }
        public string HatchRate { get; set; }
        //public ICollection<Diet> Diet { get; set; }
        public ICollection<HabitatGraphQLDto> GetHabitat([Parent] PokemonGraphQLDto pokemon, IHabitatRepository habitatRepository)
        {
            var habitats = habitatRepository.GetHabitatsByPokemonId(pokemon.Id);
            var habitatList = new List<HabitatGraphQLDto>();
            foreach (var habitat in habitats)
            {
                habitatList.Add(new HabitatGraphQLDto(habitat.Id, habitat.Name, habitat.Description));
            }
            return habitatList;
        }
        //public ICollection<Proficiency> Proficiency { get; set; }
        //public ICollection<Skill> Skill { get; set; }
        //public ICollection<Passive> Passive { get; set; }
        //public ICollection<Move> Move { get; set; }

        public PokemonGraphQLDto(
            int id,
            string name,
            int hp,
            int attack,
            int specialAttack,
            int defense,
            int specialDefense,
            int speed,
            string hatchRate)
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
