using DemoSignalR.Infrastructure;
using DemoSignalR.Models;
using Microsoft.AspNetCore.SignalR;

namespace DemoSignalR.Hubs
{
    public class ChatHub : Hub
    {
        private MessageManager _messageManager;

        public ChatHub(MessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        public async Task SendMessage(Message message)
        {
            _messageManager.AddMessage(message);
            await Clients.All.SendAsync("receiveMessage",message);
        }
    }
}
