namespace server.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int SpecialAttack { get; set; }
        public int Defense { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public ICollection<Type> Types { get; set; }
        public int SizeId { get; set; }
        public int WeightId { get; set; }
        public ICollection<EggGroup> EggGroups { get; set; }
        public string HatchRate { get; set; }
        public ICollection<Diet> Diets { get; set; }
        public ICollection<Habitat> Habitats { get; set; }
        public ICollection<Proficiency> Proficiencies { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Passive> Passives { get; set; }
        public ICollection<Move> Moves { get; set; }
    }
}
