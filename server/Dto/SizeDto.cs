namespace server.Dto
{
    public class SizeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Space { get; set; }
        public ICollection<ResourceDto> Pokemon { get; set; }

        public SizeDto(int id, string name, string space, ICollection<ResourceDto> pokemon)
        {
            Id = id;
            Name = name;
            Space = space;
            Pokemon = pokemon;
        }
    }
}
