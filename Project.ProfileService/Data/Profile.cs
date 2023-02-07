namespace Project.ProfileService.Data
{
    public class Profile
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public PatientProfile PatientProfile { get; set; }
        public SupporterProfile SupporterProfile { get; set; }
        public DoctorProfile DoctorProfile { get; set; }
        public ICollection<FamilyProfile> FamilyProfile { get; set; }
        public ICollection<FamilyProfile> FamilyRelationshipProfile { get; set; }
    }
}
