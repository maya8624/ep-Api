using Microsoft.AspNetCore.Authorization.Infrastructure;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ep.Service.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public MessageService(IMapper mapper, IRepositoryWrapper wrapper)
        {
            _mapper = mapper;
            _repository = wrapper;
        }

        //public async Task CreateMessage(Message message)
        //{
        //    await _repository.CreateAsync(message);
        //}

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
            var client = new ServiceBusClient("Endpoint=sb://az-dm-sbq.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=G8ZZpAyBTGq+0I6i7B6UUG68iyAWlx2/9+ASbODJAOQ=");
            var sender = client.CreateSender("add-dm-result");

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

            await _repository.Message.CreateAsync(message);
            await _repository.UnitOfWork.CompleteAsync();
        }
    }
}
