﻿using PrimalAPI.Interfaces;
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
            return _context.Weight.Where(w => w.Id == weightId).FirstOrDefault();
        }

        public Weight? GetWeightByName(string weightName)
        {
            return _context.Weight.Where(w => w.Name.ToLower() == weightName.ToLower()).FirstOrDefault();
        }

        public ICollection<Weight> GetWeights(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return _context.Weight.OrderBy(s => s.Id).Skip(skip).Take(paginationQuery.PageSize).ToList();
        }

        public ICollection<Weight> GetAllWeights(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return _context.Weight.OrderBy(s => s.Id).Skip(skip).Take(paginationQuery.PageSize).ToList();
        }

        public int GetWeightCount()
        {
            return _context.Weight.Count();
        }
    }
}
