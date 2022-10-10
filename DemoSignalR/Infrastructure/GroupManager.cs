using DemoSignalR.Models;

namespace DemoSignalR.Infrastructure
{
    public class GroupManager
    {
        private List<Group> _groups;
        public GroupManager()
        {
            _groups = new List<Group>();
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
    }
}
