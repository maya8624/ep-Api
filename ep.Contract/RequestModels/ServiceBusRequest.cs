using ep.Contract.RequestModels;
using FluentValidation;

namespace ep.Contract.RequestModels
{
    public class ServiceBusRequest
    {
        public string? MessageBody { get; set; }
    }
}

public class ServiceBusRequestValidator : AbstractValidator<ServiceBusRequest>
{
    public ServiceBusRequestValidator()
    {
        RuleFor(x => x.MessageBody).NotEmpty();
    }
}
