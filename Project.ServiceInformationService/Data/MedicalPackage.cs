namespace Project.ServiceInformationService.Data;

public class MedicalPackage
{
    public Guid PackageID { get; set; }
    public string PackageName { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public float EstimatedTime { get; set; }
    // Foreign Key
    public Guid SpecializationID { get; set; }

    public Specialization Specialization { get; set; }
    public ICollection<ServiceItem> ServiceItems { get; set; }

}
