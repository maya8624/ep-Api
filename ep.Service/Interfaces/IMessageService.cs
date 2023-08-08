namespace ep.Service.Interfaces
{
    public interface IMessageService
    {
        Task<bool> SendMessageResult(SendMessageRequest request);
        Task SaveMessageResult(string message);
    }
}
