namespace PrimalAPI.Models
{
    public class Diet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Pokemon> Pokemon { get; set; }
    }
}
