namespace DemoSignalR.Models
{
    public class Group
    {
        public string GroupName { get; set; }
        public List<Message> MessageList { get; set; }
        public List<User> UserList { get; set; }

        public Group(string groupname)
        {
            GroupName = groupname;
            MessageList = new List<Message>();
            UserList = new List<User>();
        }
    }
}
