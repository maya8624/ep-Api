namespace ep.Domain.Dtos
{
    public class CustomerCreateDto
    {           
        [Required]
        public string? Mobile { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? OrderNo { get; set; }

        [Required]
        public int? ShopId { get; set; }
    }
}
