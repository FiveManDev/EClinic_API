namespace Project.ProfileService.Data
{
    public class FamilyProfile
    {
        public Guid UserID { get; set; }
        public Guid PatientID { get; set; }
        public string Relationship { get; set; }
        public Profile MyProfile { get; set; }
        public Profile OtherProfile { get; set; }
    }
}
