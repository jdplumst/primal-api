namespace PrimalAPI.Dto
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ResourceDto> Pokemon { get; set; }

        public SkillDto(int id, string name, string description, ICollection<ResourceDto> pokemon)
        {
            Id = id;
            Name = name;
            Description = description;
            Pokemon = pokemon;
        }
    }
}
