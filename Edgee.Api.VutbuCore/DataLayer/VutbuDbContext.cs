using Microsoft.EntityFrameworkCore;

namespace Edgee.Api.VutbuCore.DataLayer
{
    public class VutbuDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserFinancial> UserFinancials { get; set; }

        public VutbuDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
