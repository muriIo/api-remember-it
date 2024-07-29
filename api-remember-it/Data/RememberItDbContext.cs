using api_remember_it.Models;
using Microsoft.EntityFrameworkCore;

namespace api_remember_it.Data
{
    public class RememberItDbContext : DbContext
    {
        public RememberItDbContext(DbContextOptions<RememberItDbContext> options) : base(options) { }
        public RememberItDbContext() { }

        public DbSet<User> User { get; set; }
    }
}
