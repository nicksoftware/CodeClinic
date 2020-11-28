using Microsoft.AspNetCore.Identity;

namespace CodeClinic.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string CoverImage { get; set; }
        public string AvatarImage { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }

    }
}
