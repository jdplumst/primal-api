using server.Models;
using server.Queries;

namespace server.Interfaces
{
    public interface IWeightRepository
    {
        Weight? GetWeightById(int weightId);
        Weight? GetWeightByName(string weightName);
        ICollection<Weight> GetAllWeights(PaginationQuery paginationQuery);
        int GetWeightCount();
    }
}
