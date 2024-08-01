using Microsoft.EntityFrameworkCore;
using BasicWebApp.Models; // Ensure this namespace matches your project structure

namespace BasicWebApp.Data
{
    public class BasicWebAppContext : DbContext
    {
        public BasicWebAppContext(DbContextOptions<BasicWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
