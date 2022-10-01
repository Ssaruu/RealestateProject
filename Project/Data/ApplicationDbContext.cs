using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<House> House { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

    }
}
