using server.Models;
using server.Queries;

namespace server.Interfaces
{
    public interface IHabitatRepository
    {
        Habitat? GetHabitatById(int id);
        Habitat? GetHabitatByName(string name);
        ICollection<Habitat> GetHabitats(PaginationQuery paginationQuery);
        int GetHabitatCount();
    }
}
