using ep.Domain.Models;

namespace ep.Contract.ViewModels
{
    public class CustomerView
    {
        public string? Mobile { get; set; }
        public string? Name { get; set; }
        public string? OrderNo { get; set; }
        public int? ShopId { get; set; }
        public Message? Message { get; set; }
    }
}
