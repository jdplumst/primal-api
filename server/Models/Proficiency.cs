namespace PrimalAPI.Models
{
    public class Proficiency
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required ICollection<Pokemon> Pokemon { get; set; }
        public required ICollection<Move> Move { get; set; }
    }
}
