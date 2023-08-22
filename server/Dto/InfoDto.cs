namespace server.Dto
{
    public class InfoDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }

        public InfoDto()
        {

        }

        public InfoDto(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
