using Microsoft.EntityFrameworkCore;
using OrderAPP.Entity;
using Solution.Core.Entity;
namespace Solution.Persistence
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
