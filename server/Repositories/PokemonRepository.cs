﻿using server.Interfaces;
using server.Models;

namespace server.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public ICollection<Pokemon> GetPokemonBySizeId(int sizeId)
        {
            return _context.Pokemon.Where(p => p.SizeId == sizeId).OrderBy(p => p.Id).ToList();
        }

        public ICollection<Pokemon> GetPokemonBySizeName(string sizeName)
        {
            var sizes = _context.Size.Where(s => s.Name.ToLower() == sizeName.ToLower()).Select(p => p.Id);
            return _context.Pokemon.Where(p => sizes.Contains(p.SizeId)).ToList();
        }

        public ICollection<Pokemon> GetPokemonByHabitatId(int habitatId)
        {
            return _context.Pokemon.Where(p => p.Habitat.Any(h => h.Id == habitatId)).OrderBy(p => p.Id).ToList();
        }

        public ICollection<Pokemon> GetPokemonByHabitatName(string habitatName)
        {
            return _context.Pokemon.Where(p => p.Habitat.Any(h => h.Name.ToLower() == habitatName.ToLower())).OrderBy(p => p.Id).ToList();
        }

        public ICollection<Pokemon> GetPokemonByWeightId(int weightId)
        {
            return _context.Pokemon.Where(p => p.WeightId == weightId).OrderBy(p => p.Id).ToList();
        }

        public ICollection<Pokemon> GetPokemonByWeightName(string weightName)
        {
            var weights = _context.Weight.Where(w => w.Name.ToLower() == weightName.ToLower()).Select(w => w.Id);
            return _context.Pokemon.Where(p => weights.Contains(p.WeightId)).ToList();
        }
    }
}
