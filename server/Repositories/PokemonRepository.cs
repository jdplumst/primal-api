using server.Interfaces;
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

        public ICollection<Pokemon> GetPokemonBySize(int sizeId)
        {
            return _context.Pokemon.Where(p => p.SizeId == sizeId).OrderBy(p => p.Id).ToList();
        }

        public ICollection<Pokemon> GetPokemonByHabitat(int habitatId)
        {
            return _context.Pokemon.Where(p => p.Habitat.Any(h => h.Id == habitatId)).OrderBy(p => p.Id).ToList();
        }
    }
}
