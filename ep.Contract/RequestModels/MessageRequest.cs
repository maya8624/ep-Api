using ep.Domain.Enums;
using FluentValidation;

namespace ep.Contract.RequestModels
{
    public class MessageRequest
    {
        public int CustomerId { get; set; }
        public string? Icon { get; set; }
        public string? OrderNo { get; set; }
        public int ShopId { get; set; }
        public MessageStatus Status { get; set; }
        public string? Text { get; set; }
    }

    public class MessageValidator : AbstractValidator<MessageRequest>
    {
        public MessageValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.Icon).NotEmpty();
            RuleFor(x => x.OrderNo).NotEmpty();
            RuleFor(x => x.ShopId).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.Text).NotEmpty();
        }
    }
}
