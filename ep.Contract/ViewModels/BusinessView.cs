namespace ep.Contract.ViewModels
{
    public class BusinessView : BaseView
    {
        public int Id { get; set; }
        public string? ABN { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string? Name { get; set; }
        public string? Owner { get; set; }
        public string? Phone { get; set; }
        public string? Postcode { get; set; }
        public string? Suburb { get; set; }
        public string? State { get; set; }
    }
}
