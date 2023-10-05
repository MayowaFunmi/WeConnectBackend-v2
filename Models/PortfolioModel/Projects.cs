using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WeConnectBackend.Models.ServiceCategory;

namespace WeConnectBackend.Models.PortfolioModel;

public class Projects
{
    public class Portfolio
    {
        [Key]
        public Guid PortfolioId { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public string Technologies { get; set; }
        public string SiteUrl { get; set; }
        public string GitHubUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}