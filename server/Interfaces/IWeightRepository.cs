using PrimalAPI.Models;
using PrimalAPI.Queries;

namespace PrimalAPI.Interfaces
{
    public interface IWeightRepository
    {
        Weight? GetWeightById(int weightId);
        Weight? GetWeightByName(string weightName);
        ICollection<Weight> GetWeights(PaginationQuery paginationQuery);
        int GetWeightCount();
        ICollection<Weight> GetAllWeights();
    }
}
