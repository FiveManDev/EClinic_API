namespace Project.ServiceInformationService.Data;

public class Service
{
    public Guid ServiceID { get; set; }
    public string ServiceName { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public float Price { get; set; }
    public int TotalOrder { get; set; }
    public float EstimatedTime { get; set; }
    public string Description { get; set; }

    // Foreign Key
    public ICollection<ServiceItem> ServiceItems { get; set; }

}
