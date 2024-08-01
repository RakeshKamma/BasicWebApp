using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using BasicWebApp.Models; // Ensure this namespace matches your project structure

namespace BasicWebApp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BasicWebAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<BasicWebAppContext>>()))
            {
                // Look for any users.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        Username = "testuser",
                        Password = "testpassword"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
