using System;
using System.Linq;
using System.Collections.Generic;
using Edgee.Api.VutbuCore.DataLayer;
using Edgee.Api.VutbuCore.Message;
using Microsoft.EntityFrameworkCore;

namespace Edgee.Api.VutbuCore.Services
{
    public class UserService : IUserService
    {
        private readonly VutbuDbContext _dbContext;
        public UserService(VutbuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(EditUserMessage userMessage)
        {
            // Check required info persist
            // Check username is not taken
            if (_dbContext.Users.AsNoTracking().Any(x => x.Username.ToLower().Equals(userMessage.Username.ToLower())))
            {
                throw new InvalidOperationException($"Username '{userMessage.Username}' is already taken");
            }

            // Check mobileNumber is unique
            // Check emailaddress is unique

            var newUser = new User
            {
                Name = userMessage.Name,
                Surname = userMessage.Surname,
                ProfilePhoto = userMessage.ProfilePhoto,
                Username = userMessage.Username
            };
            if (!string.IsNullOrEmpty(userMessage.EmailAddress))
            {
                newUser.UserContacts = new List<UserContact>
            {
                new UserContact {
                    EmailAddress = userMessage.EmailAddress,
                    PostCode = userMessage.PostCode,
                    TelephoneNumber = userMessage.TelephoneNumber,
                    RegionCode = userMessage.RegionCode
                }
            };
            }

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public void ChangeUsername(int userId, string newUserName)
        {
            var dbUser = _dbContext.Users.FirstOrDefault(x => x.UserId == userId);
            if (dbUser == null)
            {
                throw new ArgumentException($"User cannot be found with id {userId}");
            }
            dbUser.Username = newUserName;
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Updates name-surname-profilePhoto
        /// </summary>
        /// <param name="userMessage"></param>
        public void UpdateUser(EditUserMessage userMessage)
        {
            if (userMessage.UserId == 0 && string.IsNullOrWhiteSpace(userMessage.Username))
            {
                throw new ArgumentException($"Either user id or username must be provided");
            }

            if (userMessage.UserId == 0 && !string.IsNullOrWhiteSpace(userMessage.Username))
            {
                userMessage.UserId = GetUserIdByUserName(userMessage.Username);
            }

            var dbUser = _dbContext.Users.FirstOrDefault(x => x.UserId == userMessage.UserId);

            if (dbUser == null)
            {
                throw new ArgumentException($"User cannot be found with id {userMessage.UserId}");
            }

            dbUser.Name = userMessage.Name ?? dbUser.Name;
            dbUser.Surname = userMessage.Surname ?? dbUser.Surname;
            dbUser.ProfilePhoto = userMessage.ProfilePhoto ?? dbUser.ProfilePhoto;

            _dbContext.SaveChanges();
        }

        public int GetUserIdByUserName(string username)
        {
            var dbUser = _dbContext.Users.FirstOrDefault(x => x.Username.ToLower().Equals(username.ToLower()));
            if (dbUser != null)
            {
                return dbUser.UserId;
            }
            throw new Exception($"User not found with username {username}");
        }
    }
}
