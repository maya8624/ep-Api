using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace MessageProcessor
{
    public class Function
    {
        [FunctionName("Function")]
        public void Run([ServiceBusTrigger("customer_queue", Connection = "MessageQueueConnection")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
