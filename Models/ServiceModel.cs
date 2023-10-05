using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WeConnectBackend.Models.ServiceCategory;
using static WeConnectBackend.Models.ServiceReview;
using static WeConnectBackend.Models.UserModels.AppUsers;

namespace WeConnectBackend.Models
{
    public class ServiceModel
    {
        public enum DurationUnit
        {
            Hours,
            Days,
            Weeks,
            Months
        }
        public class Service
        {
            [Key]
            public Guid ServiceId { get; set; }
            public string UserId { get; set; }
            [ForeignKey("UserId")]
            public ApplicationUser User { get; set; }
            public Guid CategoryId { get; set; }
            [ForeignKey("CategoryId")]
            public List<Category> Category { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string? ServicePicture { get; set; }
            public int DurationQuantity {  get; set; }
            public DurationUnit DurationUnit { get; set; }
            public double Price { get; set; }
            public DateTime DeliveryTime { get; set; }
            public bool Status { get; set; } = false;
            public DateTime CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }
            public List<Review> Reviews { get; set; }
        }
    }
}
