namespace ep.Domain.Dtos
{
    public class CustomerCreateDto
    {           

        [Required]
        public string? Mobile { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Qi { get; set; }

        [Required]
        public string Qo { get; set; } = string.Empty;

        [Required]
        public string Qv{ get; set; } = string.Empty;
    }
}
