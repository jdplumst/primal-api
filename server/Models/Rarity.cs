﻿namespace PrimalAPI.Models
{
    public class Rarity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ICollection<Pokemon> Pokemon { get; set; } = default!;
    }
}