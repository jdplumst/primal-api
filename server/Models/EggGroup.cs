namespace server.Models
{
    public class EggGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Pokemon> Pokemon { get; set; }
    }
}
