namespace server.Dto
{
    public class WeightDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Range { get; set; }
        public ICollection<ResourceDto> Pokemon { get; set; }

        public WeightDto(int id, string name, string range, ICollection<ResourceDto> pokemon)
        {
            Id = id;
            Name = name;
            Range = range;
            Pokemon = pokemon;
        }
    }
}
