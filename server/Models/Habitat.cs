namespace PrimalAPI.Models
{
    public class Habitat
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required ICollection<Pokemon> Pokemon { get; set; }
    }
}
