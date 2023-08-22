﻿namespace server.Models
{
    public class Weight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Range { get; set; }
        public ICollection<Pokemon> Pokemon { get; set; }
    }
}