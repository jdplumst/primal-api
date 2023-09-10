namespace PrimalAPI.Models
{
    public class Move
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ICollection<Pokemon> Pokemon { get; set; } = default!;
        public ICollection<Proficiency> Proficiency { get; set; } = default!;
    }
}
