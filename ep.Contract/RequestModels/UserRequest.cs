using FluentValidation;

namespace ep.Contract.RequestModels
{
    public class UserRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? RefreshToken { get; set; }
    }

    public class UserValidator : AbstractValidator<UserRequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
