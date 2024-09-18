namespace PrimalAPI.Dto
{
    public class PageDto<T>
    {
        public PageDto() { }

        public PageDto(T data, InfoDto info)
        {
            Data = data;
            Info = info;
        }

        public InfoDto Info { get; set; } = default!;
        public T Data { get; set; } = default!;
    }
}
