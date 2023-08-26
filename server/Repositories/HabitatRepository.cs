using PrimalAPI.Interfaces;
using PrimalAPI.Models;
using PrimalAPI.Queries;

namespace PrimalAPI.Repositories
{
    public class HabitatRepository : IHabitatRepository
    {
        private readonly DataContext _context;

        public HabitatRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public Habitat? GetHabitatById(int id)
        {
            return _context.Habitat.Find(id);
        }

        public Habitat? GetHabitatByName(string name)
        {
            return _context.Habitat.Where(h => h.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public ICollection<Habitat> GetHabitats(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return _context.Habitat.OrderBy(h => h.Id).Skip(skip).Take(paginationQuery.PageSize).ToList();
        }

        public int GetHabitatCount()
        {
            return _context.Habitat.Count();
        }
    }
}
