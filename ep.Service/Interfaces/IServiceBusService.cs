namespace ep.Service.Interfaces
{
    public interface IServiceBusService
    {
        Task SendMessage(ServiceBusRequest request);
    }
}
