using Edgee.Api.VutbuCore.Message;

namespace Edgee.Api.VutbuCore.Services
{
    public interface IGroupService
    {
        public void CreateGroup(EditGroupMessage groupMessage);
        public void AddUserToGroup(int groupId, int userId);
        public void RemoveUserFromGroup(int groupId, int userId);
        public void SetUserAsGroupAdmin(int groupId, int userId);
        public void RemoveUserFromGroupAdmins(int groupId, int userId);
    }
}
