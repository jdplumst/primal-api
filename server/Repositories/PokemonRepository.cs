using PrimalAPI.Interfaces;
using PrimalAPI.Models;

namespace PrimalAPI.Repositories
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
            return _context.Pokemon
                .Where(p => p.SizeId == sizeId)
                .OrderBy(p => p.Id)
                .ToList();
        }

        public ICollection<Pokemon> GetPokemonBySizeName(string sizeName)
        {
            var sizes = _context.Size
                .Where(s => s.Name.ToLower() == sizeName.ToLower())
                .Select(p => p.Id);
            return _context.Pokemon
                .Where(p => sizes.Contains(p.SizeId))
                .ToList();
        }

        public ICollection<Pokemon> GetPokemonByHabitatId(int habitatId)
        {
            return _context.Pokemon
                .Where(p => p.Habitat.Any(h => h.Id == habitatId))
                .OrderBy(p => p.Id)
                .ToList();
        }

        public ICollection<Pokemon> GetPokemonByHabitatName(string habitatName)
        {
            return _context.Pokemon
                .Where(p => p.Habitat.Any(h => h.Name.ToLower() == habitatName.ToLower()))
                .OrderBy(p => p.Id)
                .ToList();
        }

        public ICollection<Pokemon> GetPokemonByWeightId(int weightId)
        {
            return _context.Pokemon
                .Where(p => p.WeightId == weightId)
                .OrderBy(p => p.Id)
                .ToList();
        }

        public ICollection<Pokemon> GetPokemonByWeightName(string weightName)
        {
            var weights = _context.Weight
                .Where(w => w.Name.ToLower() == weightName.ToLower())
                .Select(w => w.Id);
            return _context.Pokemon
                .Where(p => weights.Contains(p.WeightId))
                .ToList();
        }

        public ICollection<Pokemon> GetPokemonByRarityId(int rarityId)
        {
            return _context.Pokemon
                .Where(p => p.RarityId == rarityId)
                .OrderBy(p => p.Id)
                .ToList();
        }

        public ICollection<Pokemon> GetPokemonByEggGroupId(int eggGroupId)
        {
            return _context.Pokemon
                .Where(p => p.EggGroup.Any(e => e.Id == eggGroupId))
                .ToList();
        }

        public ICollection<Pokemon> GetRandomPokemonFromHabitat(string habitatName, int count)
        {
            return _context.Pokemon
                .Where(p => p.Habitat.Any(h => h.Name.ToLower() == habitatName.ToLower()))
                .OrderBy(p => Guid.NewGuid())
                .Take(count)
                .ToList();
        }

        public Pokemon GetRandomPokemonFromEggGroup(string eggGroupName)
        {
            return _context.Pokemon
                .Where(p => p.EggGroup.Any(e => e.Name.ToLower() == eggGroupName.ToLower()))
                .OrderBy(p => Guid.NewGuid())
                .FirstOrDefault()!;
        }
    }
}
