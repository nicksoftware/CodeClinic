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
            if (!context.IssueTickets.Any())
            {
                var categories = new List<Category>
                {
                    new Category{ Name = "Xamarin", Description ="Bug Issue Tickets related to Xamarin"},
                    new Category{ Name = "AspNet Core ", Description ="Issue Tickets related to AspNet Core"},
                    new Category{ Name = "Xamarin", Description ="Reported Bug issues for Blazor"},
                    new Category{ Name = "ML.Net", Description ="Issues Related ML.Net"},
                    new Category{ Name = "UWP", Description ="Bug Issue Tickets related to Universal Windows Platform"},
                };

                context.Categories.AddRange(categories);

                 await  context.SaveChangesAsync();
                context.IssueTickets.AddRange(
                    new List<IssueTicket>
                    {
                        new IssueTicket{
                            Title = "😥 I broke my Clients Ecommece System Please Help",
                            CategoryId = 1,
                            Body = "I was Updating to the latest version of entity framework and everything went west of westeros", 
                        },

                        new IssueTicket{
                            Title = "My Xamarin 📱 Application Has a Bug ,I cant Fix",
                            CategoryId = 2,
                            Body = "I  cant seem to create a new page ",
                        },
                        new IssueTicket{
                            Title = "😫 How do I integrate CICD on Web application",
                            CategoryId = 3,
                            Body = "Help hellp help ,I am frustrated",
                        },

                        new IssueTicket{
                            Title = "Fix me! it Says ,But ☹ I dont know How",
                            CategoryId = 4,
                            Body = "Help me pleae ,Anyone someone ",
                        },
                    }
                    );
                await context.SaveChangesAsync();
            }
        }
    }
}
