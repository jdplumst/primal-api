using server.Models;
using server.Queries;

namespace server.Interfaces
{
    public interface ISizeRepository
    {
        Size GetSize(int id);
        ICollection<Size> GetSizes(PaginationQuery paginationQuery);
        int GetSizeCount();
    }
}
