namespace PrimalAPI.Models
{
    public class Weight
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Range { get; set; } = default!;
        public ICollection<Pokemon> Pokemon { get; set; } = default!;
    }
}
