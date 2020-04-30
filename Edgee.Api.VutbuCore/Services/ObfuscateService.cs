using System;
using System.Linq;
using Edgee.Api.VutbuCore.DataLayer;
using Edgee.Api.VutbuCore.Message;
using Microsoft.EntityFrameworkCore;

namespace Edgee.Api.VutbuCore.Services
{
    public class ObfuscateService : IObfuscateService
    {
        private readonly VutbuDbContext _dbContext;
        private readonly IUserService _userService;
        private const string OBFUSCATE_STRING = "OBFUSCATED";
        private const string OBFUSCATE_POSTCODE = "AC1 0AA";
        private const string OBFUSCATE_NUMBER = "0000000000";
        private const string OBFUSCATE_EMAIL = "@email.com";

        public ObfuscateService(VutbuDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public void ObfuscateUser(EditUserMessage userMessage)
        {
            if (userMessage.UserId == 0 && string.IsNullOrWhiteSpace(userMessage.Username))
            {
                throw new ArgumentException($"Either user id or username must be provided");
            }

            if (userMessage.UserId == 0 && !string.IsNullOrWhiteSpace(userMessage.Username))
            {
                userMessage.UserId = _userService.GetUserIdByUserName(userMessage.Username);
            }

            var dbUser = _dbContext.Users.Include(b => b.UserContacts).FirstOrDefault(x => x.UserId == userMessage.UserId);

            dbUser.Name = OBFUSCATE_STRING;
            dbUser.Surname = OBFUSCATE_STRING;
            dbUser.ProfilePhoto = OBFUSCATE_STRING;

            // Obfuscate user financial
            if (dbUser.UserFinancial != null)
            {
                dbUser.UserFinancial.IBAN = OBFUSCATE_STRING;
                dbUser.UserFinancial.SortCode = OBFUSCATE_STRING;
                dbUser.UserFinancial.AccountNumber = OBFUSCATE_STRING;
            }

            // Obfuscate user contacts
            if (dbUser.UserContacts != null)
            {
                foreach (var contactInfo in dbUser.UserContacts)
                {
                    contactInfo.PostCode = OBFUSCATE_POSTCODE;
                    contactInfo.TelephoneNumber = OBFUSCATE_NUMBER;
                    contactInfo.EmailAddress = OBFUSCATE_EMAIL;
                }
            }

            _dbContext.SaveChanges();
        }
    }
}
