using FluentValidation;

namespace ep.Contract.RequestModels
{
    public class CustomerRequest
    {
        public string? Mobile { get; set; }
        public string? Name { get; set; }
        public int Qi { get; set; }
        public string Qo { get; set; } = string.Empty;
        public string Qv { get; set; } = string.Empty;
    }

    public class CustomerValidator : AbstractValidator<CustomerRequest>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Mobile).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Qi).NotEmpty();
            RuleFor(x => x.Qo).NotEmpty();
            RuleFor(x => x.Qv).NotEmpty();
        }
    }
}
