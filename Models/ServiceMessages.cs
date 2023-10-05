using System.ComponentModel.DataAnnotations;
using static WeConnectBackend.Models.UserModels.AppUsers;
using System.ComponentModel.DataAnnotations.Schema;
using static WeConnectBackend.Models.ServiceModel;

namespace WeConnectBackend.Models
{
    public class ServiceMessages
    {
        public class DirectMessage
        {
            [Key]
            public Guid MessageId { get; set; }
            public string SenderId { get; set; }
            [ForeignKey("SenderId")]
            [Required]
            public ApplicationUser Sender { get; set; }
            public string ReceiverId { get; set; }
            [ForeignKey("ReceiverId")]
            [Required]
            public ApplicationUser Receiver { get; set; }
            public Guid ServiceId { get; set; }
            [ForeignKey("ServiceId")]
            [Required]
            public Service Service { get; set; }
            public string Message { get; set; }
            public bool IsRead { get; set; } = false;
            public DateTime Timestamp { get; set; }
        }
    }
}
