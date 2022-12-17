using FluentValidation;

namespace ep.Contract.RequestModels
{
    public class BusinessRequest
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

    public class BusinessValidator : AbstractValidator<BusinessRequest>
    {
        public BusinessValidator()
        {
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Latitude).NotEmpty();
            RuleFor(x => x.Longitude).NotEmpty();
            RuleFor(x => x.Owner).NotEmpty();
        }   
    }
}
