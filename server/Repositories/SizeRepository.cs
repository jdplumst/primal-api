using PrimalAPI.Helpers;
using PrimalAPI.Interfaces;
using PrimalAPI.Models;
using PrimalAPI.Queries;

namespace PrimalAPI.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private readonly DataContext _context;

        public SizeRepository(DataContext context)
        {
            _context = context;
        }

        public Size? GetSizeById(int sizeId)
        {
            try
            {
                return _context.Size.Where(s => s.Id == sizeId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }
        }

        public Size? GetSizeByName(string name)
        {
            try
            {
                return _context
                    .Size.Where(s => s.Name.ToLower() == name.ToLower())
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }
        }

        public ICollection<Size> GetSizes(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            try
            {
                return _context
                    .Size.OrderBy(s => s.Id)
                    .Skip(skip)
                    .Take(paginationQuery.PageSize)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }
        }

        public int GetSizeCount()
        {
            try
            {
                return _context.Size.Count();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }
        }

        public Size? GetSizeByPokemonId(int pokemonId)
        {
            try
            {
                return _context
                    .Size.Where(s => s.Pokemon.Any(p => p.Id == pokemonId))
                    .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }
        }

        public ICollection<Size> GetAllSizes()
        {
            try
            {
                return _context.Size.OrderBy(s => s.Id).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }
        }
    }
}
