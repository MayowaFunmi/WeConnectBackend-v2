using System.ComponentModel.DataAnnotations;
using static WeConnectBackend.Models.UserModels.AppUsers;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeConnectBackend.Models.UserModels
{
    public class Education
    {
        public class UserEducation
        {
            [Key]
            public Guid EducationId { get; set; }
            public string UserId { get; set; }
            [ForeignKey("UserId")]
            public ApplicationUser User { get; set; }
            public string SchoolName { get; set; }
            public string Qualification { get; set; }
            public string Course { get; set; }
            public DateTime GraduationYear { get; set; }
            public DateTime Created { get; set; } = DateTime.Now;
        }
    }
}
