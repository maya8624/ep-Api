namespace ep.Contract.ViewModels
{
    public class BusinessView
    {
        public int Id { get; set; }
        public string? ABN { get; set; }
        public string? Address { get; set; }
        public string? Owner { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
