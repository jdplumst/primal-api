namespace server.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Space { get; set; }
        public ICollection<Pokemon> Pokemon { get; set; }
    }
}
