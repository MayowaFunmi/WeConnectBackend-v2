using System.ComponentModel.DataAnnotations;
using static WeConnectBackend.Models.UserModels.AppUsers;
using System.ComponentModel.DataAnnotations.Schema;
using static WeConnectBackend.Models.ServiceModel;

namespace WeConnectBackend.Models
{
    public class ServiceOrders
    {
        public class Order
        {
            [Key]
            public Guid OrderId { get; set; }
            public string SellerId { get; set; }
            [ForeignKey("SellerId")]
            [Required]
            public ApplicationUser Seller { get; set; }
            public string BuyerId { get; set; }
            [ForeignKey("BuyerId")]
            [Required]
            public ApplicationUser Buyer { get; set; }
            public Guid ServiceId { get; set; }
            [ForeignKey("ServiceId")]
            [Required]
            public Service Service { get; set; }
            public bool Completed { get; set; } = false;
            public DateTime Started { get; set; } = DateTime.Now;
            public DateTime Finished { get; set; }
        }
    }
}
