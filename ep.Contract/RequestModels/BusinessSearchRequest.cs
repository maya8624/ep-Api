namespace ep.Contract.RequestModels
{
    public class BusinessSearchRequest
    {
        public string? Name { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
