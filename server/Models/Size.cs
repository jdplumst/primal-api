namespace PrimalAPI.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Space { get; set; } = default!;
        public ICollection<Pokemon> Pokemon { get; set; } = default!;
    }
}
