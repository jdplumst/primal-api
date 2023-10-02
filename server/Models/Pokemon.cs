namespace PrimalAPI.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int HP { get; set; }
        public required int Attack { get; set; }
        public required int SpecialAttack { get; set; }
        public required int Defense { get; set; }
        public required int SpecialDefense { get; set; }
        public required int Speed { get; set; }
        public required ICollection<Type> Type { get; set; }
        public required int SizeId { get; set; }
        public required int WeightId { get; set; }
        public required ICollection<EggGroup> EggGroup { get; set; }
        public required string HatchRate { get; set; }
        public required ICollection<Diet> Diet { get; set; }
        public required ICollection<Habitat> Habitat { get; set; }
        public required ICollection<Proficiency> Proficiency { get; set; }
        public required ICollection<Skill> Skill { get; set; }
        public required ICollection<Passive> Passive { get; set; }
        public required ICollection<Move> Move { get; set; }
        public required int RarityId { get; set; }
    }
}
