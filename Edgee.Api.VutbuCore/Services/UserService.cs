using System;
using Edgee.Api.VutbuCore.Message;

namespace Edgee.Api.VutbuCore.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {

        }

        public void AddUser(EditUserMessage userMessage)
        {
            throw new NotImplementedException();
        }

        public void ChangeUsername(int userId, string newUserName)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(EditUserMessage userMessage)
        {
            throw new NotImplementedException();
        }
    }
}
