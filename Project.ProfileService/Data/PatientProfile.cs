namespace Project.ProfileService.Data
{
    public class PatientProfile
    {
        public Guid UserID { get; set; }
        public string BloodType { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public Profile Profile { get; set; }
    }
}
