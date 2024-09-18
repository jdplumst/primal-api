﻿using PrimalAPI.Interfaces;
using PrimalAPI.Models;
using PrimalAPI.Queries;
using PrimalAPI.Helpers;

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
            Size? size;

            try
            {
                size = _context.Size.Where(s => s.Id == sizeId).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }

            return size;
        }

        public Size? GetSizeByName(string name)
        {
            Size? size;

            try
            {
                size = _context.Size.Where(s => s.Name.ToLower() == name.ToLower()).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(Constants.DatabaseErrorMsg, e);
            }

            return size;
        }

        public ICollection<Size> GetSizes(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return _context.Size.OrderBy(s => s.Id).Skip(skip).Take(paginationQuery.PageSize).ToList();
        }

        public int GetSizeCount()
        {
            return _context.Size.Count();
        }

        public Size? GetSizeByPokemonId(int pokemonId)
        {
            return _context.Size.Where(s => s.Pokemon.Any(p => p.Id == pokemonId)).FirstOrDefault();
        }

        public ICollection<Size> GetAllSizes()
        {
            return _context.Size.OrderBy(s => s.Id).ToList();
        }
    }
}
