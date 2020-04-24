using Edgee.Api.Dictionary.Model;
using Microsoft.EntityFrameworkCore;

namespace Edgee.Api.Dictionary.DataLayer
{
    public class DictionaryDbContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<DictionaryItem> DictionaryItems { get; set; }

        public DictionaryDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
