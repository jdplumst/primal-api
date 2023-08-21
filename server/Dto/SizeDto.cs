namespace server.Dto
{
    public class SizeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Space { get; set; }
        public ICollection<PokemonResourceDto> Pokemon { get; set; }
    }
}
