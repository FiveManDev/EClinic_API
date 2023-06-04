using Project.ServiceInformationService.Data;

namespace Project.ServiceInformationService.Dtos.ServiceDTO;

public class ServiceDTO
{
    public Guid ServiceID { get; set; }
    public string ServiceName { get; set; }
    public double Price { get; set; }
    public int EstimatedTime { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // Foreign Key
    public Specialization Specialization { get; set; }
}
