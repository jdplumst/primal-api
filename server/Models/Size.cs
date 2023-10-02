namespace PrimalAPI.Models
{
    public class Size
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Space { get; set; }
        public required ICollection<Pokemon> Pokemon { get; set; }
    }
}
