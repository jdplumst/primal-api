namespace PrimalAPI.Models
{
    public class EggGroup
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required ICollection<Pokemon> Pokemon { get; set; }
    }
}
