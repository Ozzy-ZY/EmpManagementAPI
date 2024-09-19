namespace DataAccess.Models
{
    internal class AppUser
    {
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
    }
}
