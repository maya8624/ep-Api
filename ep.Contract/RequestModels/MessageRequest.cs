using ep.Domain.Enums;
using FluentValidation;

namespace ep.Contract.RequestModels
{
    public class MessageRequest
    {
        public DateTimeOffset MessageSentOn { get; set; }
        public int MessageType { get; set; }
        public string? Mobile { get; set; }
        public string? Name { get; set; }
        public int ShopId { get; set; }
        public MessageStatus Status { get; set; }
    }

    public class MessageValidator : AbstractValidator<MessageRequest>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageSentOn).NotEmpty();
            RuleFor(x => x.Mobile).NotEmpty();
            RuleFor(x => x.MessageType).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ShopId).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}
