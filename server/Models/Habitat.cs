﻿namespace server.Models
{
    public class Habitat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Pokemon> Pokemon { get; set; }
    }
}
