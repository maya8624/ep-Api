namespace ep.Service.Services
{
    public class ServiceBusService : IServiceBusService
    {
        private readonly IConfiguration _config;

        public ServiceBusService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendMessage(ServiceBusRequest request)
        {
            var sender = GetServiceBusSender();
            var message = new ServiceBusMessage(request.MessageBody);
            await sender.SendMessageAsync(message);
        }

        private ServiceBusSender GetServiceBusSender()
        {
            var serviceBus = _config.GetSection("AzureServiceBus");
            var connectionString = serviceBus.GetValue<string>("ConnectionString");
            var queueName = serviceBus.GetValue<string>("QueueName");

            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queueName);
            return sender;
        }
    }
}
