﻿namespace PrimalAPI.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Pokemon> Pokemon { get; set; }
    }
}
