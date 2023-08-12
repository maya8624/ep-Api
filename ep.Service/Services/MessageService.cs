using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ep.Service.Services
{
    public class MessageService : IMessageService
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public MessageService(IConfiguration config, IMapper mapper, IRepositoryWrapper wrapper)
        {
            _config = config;
            _mapper = mapper;
            _repository = wrapper;
        }

        public async Task<bool> CreateMessage(MessageRequest request)
        {
            var message = _mapper.Map<Message>(request);
            await _repository.Message.Create(message);
            var result = await _repository.UnitOfWork.CompleteAsync();
            return result < 1;
        }

        //public async Task<Message> GetMessageByOrderNo(int shopId, string orderNo)
        //{
        //    return await _repository.GetByOrderNoAsync(shopId, orderNo);
        //}

        //public void UpdateMessage(Message message)
        //{
        //    _repository.Update(message);
        //}

        public async Task<bool> SendMessageResult(SendMessageRequest request)
        {
            var serviceBus = _config.GetSection("AzureServiceBus");
            var connectionString = serviceBus.GetValue<string>("ConnectionString");
            var queueName = serviceBus.GetValue<string>("QueueName");

            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queueName);

            var body = JsonSerializer.Serialize(request);
            var message = new ServiceBusMessage(body);
            await sender.SendMessageAsync(message);

            //var batch = await sender.CreateMessageBatchAsync();
            //batch.TryAddMessage(new ServiceBusMessage(body));
            //await sender.SendMessagesAsync(batch);

            return true;
        }

        public async Task SaveMessageResult(string messageJson)
        {
            var message = JsonSerializer.Deserialize<Message>(messageJson);
            ArgumentNullException.ThrowIfNull(message);

            await _repository.Message.Create(message);
            await _repository.UnitOfWork.CompleteAsync();
        }
    }
}
