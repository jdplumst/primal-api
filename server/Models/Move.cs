namespace PrimalAPI.Models
{
    public class Move
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required ICollection<Pokemon> Pokemon { get; set; }
        public required ICollection<Proficiency> Proficiency { get; set; }
    }
}
