using server.Models;
using server.Queries;

namespace server.Interfaces
{
    public interface ISizeRepository
    {
        Size? GetSizeById(int id);
        Size? GetSizeByName(string name);
        ICollection<Size> GetSizes(PaginationQuery paginationQuery);
        int GetSizeCount();
    }
}
