namespace Project.ServiceInformationService.Data;

public class ServiceItem
{
    public Guid ServiceID { get; set; }
    public Guid PackageID { get; set; }

    // Foreign Key
    public Service Service { get; set; }
    public MedicalPackage MedicalPackage { get; set; }

}
