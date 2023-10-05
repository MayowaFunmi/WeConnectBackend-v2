using System.ComponentModel.DataAnnotations;

namespace WeConnectBackend.Models
{
    public class ServiceCategory
    {
        public class Category
        {
            [Key]
            public Guid CategoryId { get; set; }
            public string Name { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }
    }
}
