using server.Interfaces;
using server.Models;
using server.Queries;

namespace server.Repositories
{
    public class HabitatRepository : IHabitatRepository
    {
        private readonly DataContext _context;

        public HabitatRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public Habitat GetHabitat(int id)
        {
            return _context.Habitat.Find(id);
        }

        public ICollection<Habitat> GetHabitats(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return _context.Habitat.Skip(skip).Take(paginationQuery.PageSize).ToList();
        }

        public int GetHabitatCount()
        {
            return _context.Habitat.Count();
        }
    }
}
