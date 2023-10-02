namespace PrimalAPI.Models
{
    public class Weight
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Range { get; set; }
        public required ICollection<Pokemon> Pokemon { get; set; }
    }
}
