using PrimalAPI.Helpers;
using PrimalAPI.Interfaces;
using PrimalAPI.Models;
using PrimalAPI.Queries;

namespace PrimalAPI.Repositories
{
    public class WeightRepository : IWeightRepository
    {
        private readonly DataContext _context;

        public WeightRepository(DataContext context)
        {
            _context = context;
        }

        public Weight? GetWeightById(int weightId)
        {
            try
            {
                return _context.Weight.Where(w => w.Id == weightId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }
        }

        public Weight? GetWeightByName(string weightName)
        {
            return _context
                .Weight.Where(w => w.Name.ToLower() == weightName.ToLower())
                .FirstOrDefault();
        }

        public ICollection<Weight> GetWeights(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return _context
                .Weight.OrderBy(w => w.Id)
                .Skip(skip)
                .Take(paginationQuery.PageSize)
                .ToList();
        }

        public int GetWeightCount()
        {
            return _context.Weight.Count();
        }

        public Weight? GetWeightByPokemonId(int pokemonId)
        {
            return _context
                .Weight.Where(w => w.Pokemon.Any(p => p.Id == pokemonId))
                .FirstOrDefault();
        }

        public ICollection<Weight> GetAllWeights()
        {
            return _context.Weight.OrderBy(w => w.Id).ToList();
        }
    }
}
