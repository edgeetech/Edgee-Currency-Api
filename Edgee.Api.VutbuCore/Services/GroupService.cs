using System;
using System.Collections.Generic;
using System.Linq;
using Edgee.Api.VutbuCore.DataLayer;
using Edgee.Api.VutbuCore.Message;
using Microsoft.EntityFrameworkCore;

namespace Edgee.Api.VutbuCore.Services
{
    public class GroupService : IGroupService
    {
        private readonly VutbuDbContext _dbContext;
        public GroupService(VutbuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUserToGroup(int groupId, int userId)
        {
            if(groupId==0 || userId == 0)
            {
                throw new ArgumentException("GroupId and UserId must be provided");
            }

            // Check user exists

            // Check group exists

            // Check user is already a member
            var dbItem = _dbContext.UserGroups.FirstOrDefault(x => x.GroupId == groupId && x.UserId == userId);
            if (dbItem != null)
            {
                dbItem.IsActive = true;
                dbItem.LeaveDate = null;
            }
            else
            {
                _dbContext.UserGroups.Add(new UserGroup { GroupId = groupId, UserId = userId, IsActive = true, JoinDate = DateTime.Now });
            }
            _dbContext.SaveChanges();
        }

        public void CreateGroup(EditGroupMessage groupMessage)
        {
            if (string.IsNullOrWhiteSpace(groupMessage.Name))
            {
                throw new ArgumentException("Group should have a name");
            }
            if (groupMessage.GroupAdminId == 0)
            {
                throw new ArgumentException("Group should have an admin user");
            }

            var newGroup = new Group
            {
                Name = groupMessage.Name,
                Description = groupMessage.Description,
                GroupPhoto = groupMessage.GroupPhoto
            };

            newGroup.GroupAdmins = new List<GroupAdmin> { new GroupAdmin { UserId = groupMessage.GroupAdminId } };
            _dbContext.Groups.Add(newGroup);
            _dbContext.SaveChanges();

            // Creator is the natural member of the group
            AddUserToGroup(newGroup.GroupId, groupMessage.GroupAdminId);
        }

        public void RemoveUserFromGroup(int groupId, int userId)
        {
            // Check user is a member
            var dbItem = _dbContext.UserGroups.FirstOrDefault(x => x.GroupId == groupId && x.UserId == userId && x.IsActive);
            if (dbItem == null)
            {
                throw new InvalidOperationException("User is not a member of this group");
            }
            dbItem.IsActive = false;
            dbItem.LeaveDate = DateTime.Now;
            _dbContext.SaveChanges();
        }

        public void SetUserAsGroupAdmin(int groupId, int userId)
        {
            var dbItem = _dbContext.GroupAdmins.AsNoTracking().FirstOrDefault(x => x.GroupId == groupId && x.UserId == userId);
            if (dbItem != null)
            {
                throw new InvalidOperationException("User is already admin of this group");
            }
            _dbContext.GroupAdmins.Add(new GroupAdmin
            {
                GroupId = groupId,
                UserId = userId
            });
            _dbContext.SaveChanges();
        }

        public void RemoveUserFromGroupAdmins(int groupId, int userId)
        {
            var dbItem = _dbContext.GroupAdmins.FirstOrDefault(x => x.GroupId == groupId && x.UserId == userId);
            if (dbItem == null)
            {
                throw new InvalidOperationException("User is not an admin of this group");
            }

            if (_dbContext.GroupAdmins.AsNoTracking().Count(x => x.GroupId == groupId) == 1) {
                throw new InvalidOperationException("A group must have an admin");
            }

            _dbContext.GroupAdmins.Remove(dbItem);
            _dbContext.SaveChanges();
        }
    }
}
