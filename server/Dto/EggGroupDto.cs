namespace PrimalAPI.Dto
{
    public class EggGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ResourceDto> Pokemon { get; set; }

        public EggGroupDto(int id, string name, ICollection<ResourceDto> pokemon)
        {
            Id = id;
            Name = name;
            Pokemon = pokemon;
        }
    }
}