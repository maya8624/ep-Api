namespace ep.Contract.ViewModels
{
    public class BusinessView
    {
        public string? ABN { get; set; }
        public string? Address { get; set; }
        public string? Owner { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
