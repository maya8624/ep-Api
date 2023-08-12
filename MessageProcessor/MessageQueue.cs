using System;
using ep.Service.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace MessageProcessor
{
    public class MessageQueue
    {
        private readonly IMessageService _messageService;

        public MessageQueue(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [FunctionName("MessageQueue")]
        public void Run([ServiceBusTrigger("customer_queue", Connection = "MessageQueueConnection")]string message, ILogger log)
        {
            try
            {
                _messageService.SaveMessageResult(message);
                log.LogInformation($"message: {message}");
            }
            catch (Exception ex)
            {
                log.LogInformation($"error: {ex.Message}");
                throw;
            }
        }
    }
}
