namespace PrimalAPI.Models
{
    public class Diet
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required ICollection<Pokemon> Pokemon { get; set; }
    }
}
