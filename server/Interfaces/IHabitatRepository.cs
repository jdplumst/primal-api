using server.Models;
using server.Queries;

namespace server.Interfaces
{
    public interface IHabitatRepository
    {
        Habitat GetHabitat(int id);
        ICollection<Habitat> GetHabitats(PaginationQuery paginationQuery);
        int GetHabitatCount();
    }
}
