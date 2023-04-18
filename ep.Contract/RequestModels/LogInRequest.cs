using FluentValidation;

namespace ep.Contract.RequestModels
{
    public class LogInRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LogInValidator : AbstractValidator<LogInRequest>
    {
        public LogInValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
