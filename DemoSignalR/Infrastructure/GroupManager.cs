using DemoSignalR.Models;

namespace DemoSignalR.Infrastructure
{
    public class GroupManager
    {
        private List<Group> _groups;
        public GroupManager()
        {
            _groups = new List<Group>
            {
                new Group("TBNet"),
                new Group("Formateur")
            };
        }

        public List<Group> GetGroups()
        {
            return _groups;
        }

        public void AddUserToGroup(User u, string groupname)
        {
            Group group = _groups.FirstOrDefault(g => g.GroupName == groupname);
            if (group == null)
            {
                group = new Group(groupname);
                _groups.Add(group);
            }
            group.UserList.Add(u);
            
        }

        public void AddMessageToGroup(Message m , string groupname)
        {
            Group group = _groups.FirstOrDefault(g => g.GroupName == groupname);
            if (group == null) throw new Exception("Groupe inexistant");
            group.MessageList.Add(m);
        }
    }
}
