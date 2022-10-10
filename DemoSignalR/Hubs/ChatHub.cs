using DemoSignalR.Infrastructure;
using DemoSignalR.Models;
using Microsoft.AspNetCore.SignalR;

namespace DemoSignalR.Hubs
{
    public class ChatHub : Hub
    {
        private MessageManager _messageManager;
        private GroupManager _groupManager;

        public ChatHub(MessageManager messageManager, GroupManager groupManager)
        {
            _messageManager = messageManager;
            _groupManager = groupManager;
        }

        public async Task SendMessage(Message message)
        {
            _messageManager.AddMessage(message);
            await Clients.All.SendAsync("receiveMessage",message);
        }

        public async Task JoinGroup(string groupname, string username)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupname);

            await SendToGroup(
                new Message
                {
                    Author = "System",
                    Content = $"{username} à rejoint le groupe"
                }, groupname);

            _groupManager.AddUserToGroup(new User { 
                Username = username, 
                ConnectionId = Context.ConnectionId },
                groupname);
        }

        public async Task SendToGroup(Message message, string groupname)
        {
            await Clients.Group(groupname).SendAsync("togroup", message);
        }
    }
}
