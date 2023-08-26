﻿using server.Interfaces;
using server.Models;
using server.Queries;

namespace server.Repositories
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
            return _context.Weight.Where(w => w.Name == weightName).FirstOrDefault();
        }

        public ICollection<Weight> GetAllWeights(PaginationQuery paginationQuery)
        {
            var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
            return _context.Weight.Skip(skip).Take(paginationQuery.PageSize).OrderBy(s => s.Id).ToList();
        }

        public int GetWeightCount()
        {
            return _context.Weight.Count();
        }
    }
}