namespace Project.ProfileService.Data
{
    public class DoctorProfile
    {
        public Guid ProfileID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime WorkStart { get; set; }
        public Guid SpecializationID { get; set; }
        public float Quality { get; set; }
        public Profile Profile { get; set; }
    }
}
