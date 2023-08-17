namespace server.Models
{
    public class Passive
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PassiveType Type { get; set; }
        public ICollection<Pokemon> Pokemon { get; set; }
    }

    public enum PassiveType
    {
        Stat,
        Ability
    }
}
