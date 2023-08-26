namespace PrimalAPI.Dto
{
    public class HabitatDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ResourceDto> Pokemon { get; set; }

        public HabitatDto(int id, string name, string description, ICollection<ResourceDto> pokemon)
        {
            Id = id;
            Name = name;
            Description = description;
            Pokemon = pokemon;

        }
    }
}
