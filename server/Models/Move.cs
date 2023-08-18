namespace server.Models
{
    public class Move
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Pokemon> Pokemon { get; set; }
        public ICollection<Proficiency> Proficiency { get; set; }
    }
}
