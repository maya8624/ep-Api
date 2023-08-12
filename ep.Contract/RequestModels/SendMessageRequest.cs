using ep.Contract.RequestModels;
using ep.Domain.Enums;
using FluentValidation;

namespace ep.Contract.RequestModels
{
    public class SendMessageRequest
    {
        public string? Mobile { get; set; }
        public string? Name { get; set; }
        public string? OrderNo { get; set; }        
        public int ShopId { get; set; }
        public MessageStatus Status { get; set; }
        public string? Text { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}

public class MessageServiceValidator : AbstractValidator<SendMessageRequest>
{
    public MessageServiceValidator()
    {
        RuleFor(x => x.Mobile).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Status).NotEmpty();
        RuleFor(x => x.OrderNo).NotEmpty();
        RuleFor(x => x.ShopId).NotEmpty();
        RuleFor(x => x.Text).NotEmpty();
    }
}