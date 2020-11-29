using CodeClinic.Domain.Entities;
using CodeClinic.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodeClinic.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        private static ApplicationUser _defaultUser;

        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            _defaultUser = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com" };

            if (userManager.Users.All(u => u.UserName != _defaultUser.UserName))
            {
                await userManager.CreateAsync(_defaultUser, "P@ssw0rd");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            //if (!context.IssueTickets.Any())
            //{
            //    var categories = new List<Category>
            //    {
            //        new Category{CreatedBy=_defaultUser.Id, Name = "Xamarin", Description ="Bug Issue Tickets related to Xamarin"},
            //        new Category{CreatedBy=_defaultUser.Id, Name = "AspNet Core ", Description ="Issue Tickets related to AspNet Core"},
            //        new Category{CreatedBy=_defaultUser.Id, Name = "Xamarin", Description ="Reported Bug issues for Blazor"},
            //        new Category{CreatedBy=_defaultUser.Id, Name = "ML.Net", Description ="Issues Related ML.Net"},
            //        new Category{CreatedBy=_defaultUser.Id, Name = "UWP", Description ="Bug Issue Tickets related to Universal Windows Platform"},
            //    };

            //    context.Categories.AddRange(categories);

            //    await context.SaveChangesAsync();

            //    context.IssueTickets.AddRange(
            //        new List<IssueTicket>
            //        {
            //            new IssueTicket{
            //                Created = DateTime.Now,
            //                CreatedBy = _defaultUser.Id,
            //                Title = "😥 I broke my Clients Ecommece System Please Help",
            //                CategoryId = 1,
            //                Status = Domain.Enums.ProgressStatus.InDiscussion,
            //                Body = "I was Updating to the latest version of entity framework and everything went west of westeros",

            //            },

            //            new IssueTicket{
            //                Created = DateTime.Now,
            //                CreatedBy = _defaultUser.Id,
            //                Title = "My Xamarin 📱 Application Has a Bug ,I cant Fix",
            //                CategoryId = 2,
            //                Body = "I  cant seem to create a new page ",
            //            },
            //            new IssueTicket{
            //                Created = DateTime.Now,
            //                CreatedBy = _defaultUser.Id,
            //                Title = "😫 How do I integrate CICD on Web application",
            //                CategoryId = 3,
            //                Body = "Help hellp help ,I am frustrated",
            //            },

            //            new IssueTicket{
            //                Created = DateTime.Now,
            //                CreatedBy = _defaultUser.Id,
            //                Title = "Fix me! it Says ,But ☹ I dont know How",
            //                CategoryId = 4,
            //                Body = "Help me pleae ,Anyone someone ",
            //            },
            //        }
            //        );

            //    var comments = new List<Comment>
            //    {
            //        new Comment
            //        {
            //            IssueTicketId = 3,
            //            Created = DateTime.Now,
            //            CreatedBy = _defaultUser.Id,
            //            Title = "Provide more details",
            //            Description="Can you describe the problem you facing "

            //        },
            //        new Comment
            //        {
            //            IssueTicketId = 2,
            //            Created = DateTime.Now,
            //            CreatedBy = _defaultUser.Id,
            //            Title="Here  is how you should debug your app",
            //            Description ="If you were updating to 6.4 which is the latest current version at the time this was posted ,you should be aware that certain implementations where changed you I will show you where to " +
            //                    "change on your previous version else if this  doesn help open the docs,should refer to the docs",

            //        },
            //        new Comment
            //        {
            //            IssueTicketId = 3,
            //            Created = DateTime.Now,
            //            CreatedBy = _defaultUser.Id,
            //            Title="Here  is how you should debug your app",
            //            Description ="If you were updating to 6.4 which is the latest current version at the time this was posted ,you should be aware that certain implementations where changed you I will show you where to " +
            //                    "change on your previous version else if this  doesn help open the docs,should refer to the docs",

            //        },
            //        new Comment
            //        {
            //            IssueTicketId =1,
            //            Created = DateTime.Now,
            //            CreatedBy = _defaultUser.Id,
            //            Title="Here  is how you should debug your app",
            //            Description ="If you were updating to 6.4 which is the latest current version at the time this was posted ,you should be aware that certain implementations where changed you I will show you where to " +
            //                    "change on your previous version else if this  doesn help open the docs,should refer to the docs",

            //        }
            //    };

            //    context.Comments.AddRange(comments);
            //    await context.SaveChangesAsync();
            //}
        }
    }
}
