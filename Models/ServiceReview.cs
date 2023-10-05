using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WeConnectBackend.Models.ServiceModel;
using static WeConnectBackend.Models.UserModels.AppUsers;

namespace WeConnectBackend.Models
{
    public class ServiceReview
    {
        public class Review
        {
            [Key]
            public Guid ReviewId { get; set; }
            public string ReviewerId { get; set; }
            [ForeignKey("ReviewerId")]
            [Required]
            public ApplicationUser Reviewer { get; set; }
            public Guid ServiceId { get; set; }
            [ForeignKey("ServiceId")]
            [Required]
            public Service Service { get; set; }
            public double Rating { get; set; }
            public string Comment { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }
    }
}
