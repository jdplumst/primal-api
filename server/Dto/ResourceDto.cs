namespace server.Dto
{
    public class ResourceDto
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public ResourceDto(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}
