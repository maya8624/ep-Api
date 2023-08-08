namespace ep.Service.Interfaces
{
    public interface IMessageService
    {
        Task<bool> CreateMessage(MessageRequest request);
        Task<bool> SendMessageResult(SendMessageRequest request);
        Task SaveMessageResult(string message);
    }
}
