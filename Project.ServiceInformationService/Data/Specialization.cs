namespace Project.ServiceInformationService.Data;

public class Specialization 
{
    public Guid SpecializationID { get; set; }
    public string SpecializationName { get; set; }

    // Foreign Key
    public ICollection<MedicalPackage> MedicalPackages { get; set; }

}
