namespace PrimalAPI.Models
{
    public class Passive
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required PassiveType Type { get; set; }
        public required ICollection<Pokemon> Pokemon { get; set; }
    }

    public enum PassiveType
    {
        Stat,
        Ability,
    }
}
