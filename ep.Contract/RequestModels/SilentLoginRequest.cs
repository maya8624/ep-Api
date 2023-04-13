using FluentValidation;
namespace ep.Contract.RequestModels
{
    public class SilentLoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class SilentLoginRequestValidator : AbstractValidator<SilentLoginRequest>
    {
        public SilentLoginRequestValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.RefreshToken).NotEmpty();
            RuleFor(x => x.Role).NotEmpty();
        }
    }
}
