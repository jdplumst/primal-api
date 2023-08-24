using server.Interfaces;
using server.Models;
using server.Queries;

namespace server.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private readonly DataContext _context;

        public SizeRepository(DataContext context)
        {
            _context = context;
        }

        public Size GetSize(int id)
        {
            return _context.Size.Find(id);
        }

        public ICollection<Size> GetSizes(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return _context.Size.Skip(skip).Take(paginationQuery.PageSize).ToList();
        }

        public int GetSizeCount()
        {
            return _context.Size.Count();
        }
    }
}
