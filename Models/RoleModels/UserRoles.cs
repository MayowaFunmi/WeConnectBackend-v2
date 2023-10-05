using System.ComponentModel.DataAnnotations;

namespace WeConnectBackend.Models.RoleModels
{
    public class UserRoles
    {
        public class Role
        {
            [Key]
            public int Id { get; set; }
            public string? UserRole { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }
    }
}
