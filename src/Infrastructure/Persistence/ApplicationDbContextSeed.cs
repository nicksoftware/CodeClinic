using CodeClinic.Domain.Entities;
using CodeClinic.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "P@ssw0rd");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Issues.Any())
            {
                context.Issues.AddRange(
                    new List<Issue>
                    {
                        new Issue{
                            Title = "😥 I broke my Clients Ecommece System Please Help",
                            Body = "I was Updating to the latest version of entity framework and everything went west of westeros", 
                        },

                        new Issue{
                            Title = "My Xamarin 📱 Application Has a Bug ,I cant Fix",
                            Body = "I  cant seem to create a new page ",
                        },
                    }
                    );
                await context.SaveChangesAsync();
            }
        }
    }
}
