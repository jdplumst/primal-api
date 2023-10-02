using PrimalAPI.Queries;

namespace PrimalAPI.Dto
{
    public class InfoDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? NextPage { get; set; }
        public string? PreviousPage { get; set; }

        public InfoDto(int pageNumber, int pageSize, int totalSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            var skip = (pageNumber - 1) * pageSize;
            if (pageNumber > 1)
            {
                PreviousPage = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
                    ? Environment.GetEnvironmentVariable("DEV_SERVER_URL") +
                    "/size?pageNumber=" + (pageNumber - 1) + "&pageSize=" + pageSize
                    : Environment.GetEnvironmentVariable("PROD_SERVER_URL") +
                    "/size?pageNumber=" + (pageNumber - 1) + "&pageSize=" + pageSize;
            }
            if (skip + pageSize < totalSize)
            {
                NextPage = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
                    ? Environment.GetEnvironmentVariable("DEV_SERVER_URL") +
                    "/size?pageNumber=" + (pageNumber + 1) + "&pageSize=" + pageSize
                    : Environment.GetEnvironmentVariable("PROD_SERVER_URL") +
                    "/size?pageNumber=" + (pageNumber + 1) + "&pageSize=" + pageSize;
            }
        }

        public InfoDto(PaginationQuery paginationQuery, int totalSize)
        {
            PageNumber = paginationQuery.PageNumber;
            PageSize = paginationQuery.PageSize;
            var skip = (PageNumber - 1) * PageSize;
            if (PageNumber > 1)
            {
                PreviousPage = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
                    ? Environment.GetEnvironmentVariable("DEV_SERVER_URL") +
                    "/size?pageNumber=" + (PageNumber - 1) + "&pageSize=" + PageSize
                    : Environment.GetEnvironmentVariable("PROD_SERVER_URL") +
                    "/size?pageNumber=" + (PageNumber - 1) + "&pageSize=" + PageSize;
            }
            if (skip + PageSize < totalSize)
            {
                NextPage = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"
                    ? Environment.GetEnvironmentVariable("DEV_SERVER_URL") +
                    "/size?pageNumber=" + (PageNumber + 1) + "&pageSize=" + PageSize
                    : Environment.GetEnvironmentVariable("PROD_SERVER_URL") +
                    "/size?pageNumber=" + (PageNumber + 1) + "&pageSize=" + PageSize;
            }
        }
    }
}
