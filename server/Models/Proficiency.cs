namespace PrimalAPI.Models
{
    public class Proficiency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Pokemon> Pokemon { get; set; }
        public ICollection<Move> Move { get; set; }
    }
}
