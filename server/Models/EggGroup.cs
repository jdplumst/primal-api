namespace PrimalAPI.Models
{
    public class EggGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<Pokemon> Pokemon { get; set; } = default!;
    }
}
