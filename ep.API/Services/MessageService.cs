namespace ep.API.Services
{
    public class MessageService
    {
        private readonly ILogger _logger;
        private readonly IMessageRepository _repository;

        public MessageService(ILogger logger, IMessageRepository repository)
        {
            _logger = logger;
            _repository = repository;
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
    }
}
