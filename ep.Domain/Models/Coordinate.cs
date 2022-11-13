namespace ep.Domain.Models
{
    public class Coordinate
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public Shop Shop { get; set; }
    }
}
