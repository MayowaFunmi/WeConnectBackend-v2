using Microsoft.AspNetCore.Identity;
using static WeConnectBackend.Models.UserModels.AppUsers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static WeConnectBackend.Models.ServiceModel;
using static WeConnectBackend.Models.UserModels.Education;
using static WeConnectBackend.Models.ServiceReview;

namespace WeConnectBackend.Models.UserModels
{
    public class Profiles
    {
        public class UserProfile
        {
            [Key]
            public Guid Id { get; set; }
            public string UserId { get; set; }
            [ForeignKey("UserId")]
            public ApplicationUser User { get; set; }
            public string Gender { get; set; }
            public string MaritalStatus { get; set; }
            public string Occupation { get; set; }
            public string Address { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Nationality { get; set; }
            public string? ProfilePicture { get; set; }
            public List<IdentityRole> Roles { get; set; }
            public List<Service> Service { get; set; }
            public List<Review> Reviews { get; set; }
            public List<UserEducation> UserEducation { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }
    }
}
