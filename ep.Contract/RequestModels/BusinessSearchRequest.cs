namespace ep.Contract.RequestModels
{
    public class BusinessSearchRequest
    {
        public string? Keyword { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
