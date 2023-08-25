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

        public Size? GetSizeById(int id)
        {
            return _context.Size.Find(id);
        }

        public Size? GetSizeByName(string name)
        {
            return _context.Size.Where(s => s.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public ICollection<Size> GetSizes(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return _context.Size.Skip(skip).Take(paginationQuery.PageSize).OrderBy(s => s.Id).ToList();
        }

        public int GetSizeCount()
        {
            return _context.Size.Count();
        }
    }
}
