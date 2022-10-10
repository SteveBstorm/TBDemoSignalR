using DemoSignalR.Models;

namespace DemoSignalR.Infrastructure
{
    public class MessageManager
    {
        private List<Message> messageList;

        public MessageManager()
        {
            messageList = new List<Message>();
        }

        public List<Message> GetAll()
        {
            return messageList;
        }

        public void AddMessage(Message m)
        {
            messageList.Add(m);
        }
    }
}
