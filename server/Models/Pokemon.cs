namespace PrimalAPI.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int HP { get; set; } = default!;
        public int Attack { get; set; } = default!;
        public int SpecialAttack { get; set; } = default!;
        public int Defense { get; set; } = default!;
        public int SpecialDefense { get; set; } = default!;
        public int Speed { get; set; } = default!;
        public ICollection<Type> Type { get; set; } = default!;
        public int SizeId { get; set; } = default!;
        public int WeightId { get; set; } = default!;
        public ICollection<EggGroup> EggGroup { get; set; } = default!;
        public string HatchRate { get; set; } = default!;
        public ICollection<Diet> Diet { get; set; } = default!;
        public ICollection<Habitat> Habitat { get; set; } = default!;
        public ICollection<Proficiency> Proficiency { get; set; } = default!;
        public ICollection<Skill> Skill { get; set; } = default!;
        public ICollection<Passive> Passive { get; set; } = default!;
        public ICollection<Move> Move { get; set; } = default!;
        public int RarityId { get; set; } = default!;
    }
}
