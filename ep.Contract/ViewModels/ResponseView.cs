namespace ep.Contract.ViewModels
{
    public class ResponseView<T>
    {
        public T Data { get; set; }
        public int TotalCount { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public ResponseView(T data, int totalCount)
        {
            Data = data;
            TotalCount =  totalCount;
            Timestamp = DateTimeOffset.UtcNow;
        }
    };
}
