namespace Project.ProfileService.Dtos.UserProfile
{
    public class CreateUserProfileDtos
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile Avatar { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BloodType { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public Guid RelationshipID { get; set; }
    }
}
