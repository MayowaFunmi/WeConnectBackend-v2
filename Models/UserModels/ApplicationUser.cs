using Microsoft.AspNetCore.Identity;

namespace WeConnectBackend.Models.UserModels;
public class AppUsers
{
    public class ApplicationUser : IdentityUser
    {
        public string RegisterNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}