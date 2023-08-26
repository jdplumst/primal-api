namespace PrimalAPI.Models
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
        public ICollection<Type> Type { get; set; }
        public int SizeId { get; set; }
        public int WeightId { get; set; }
        public ICollection<EggGroup> EggGroup { get; set; }
        public string HatchRate { get; set; }
        public ICollection<Diet> Diet { get; set; }
        public ICollection<Habitat> Habitat { get; set; }
        public ICollection<Proficiency> Proficiencie { get; set; }
        public ICollection<Skill> Skill { get; set; }
        public ICollection<Passive> Passive { get; set; }
        public ICollection<Move> Move { get; set; }
    }
}
