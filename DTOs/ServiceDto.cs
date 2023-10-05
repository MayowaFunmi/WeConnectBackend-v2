using static WeConnectBackend.Models.ServiceModel;

namespace WeConnectBackend.DTOs;

public class ServiceDto
{
    public string UserId { get; set; }
    public Guid CategoryId { get; set; }
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
}