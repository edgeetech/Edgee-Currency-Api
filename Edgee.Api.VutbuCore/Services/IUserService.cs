using Edgee.Api.VutbuCore.Message;

namespace Edgee.Api.VutbuCore.Services
{
    public interface IUserService
    {
        public void AddUser(EditUserMessage userMessage);
        public void UpdateUser(EditUserMessage userMessage);
        public void ChangeUsername(int userId, string newUserName);
        public int GetUserIdByUserName(string newUserName);
    }
}
