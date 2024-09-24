using Microsoft.AspNetCore.Identity;

namespace DataAccess.Models
{
    public class AppUser: IdentityUser
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
