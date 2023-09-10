﻿namespace PrimalAPI.Models
{
    public class Passive
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public PassiveType Type { get; set; } = default!;
        public ICollection<Pokemon> Pokemon { get; set; } = default!;
    }

    public enum PassiveType
    {
        Stat,
        Ability
    }
}
