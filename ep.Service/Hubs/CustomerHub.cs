using Microsoft.AspNetCore.SignalR;

namespace ep.API.Service.Hubs
{
    public class CustomerHub : Hub
    {
        public async Task SendMessage(string user, string message)
        { 
            await Clients.Client("D").SendAsync("ReceiveMessage", user, message);
        
        }
    }
}
