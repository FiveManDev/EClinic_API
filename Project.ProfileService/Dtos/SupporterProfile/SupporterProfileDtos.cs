using Project.ProfileService.Data;

namespace Project.ProfileService.Dtos.SupporterProfile
{
    public class SupporterProfileDtos
    {
        public Guid ProfileID { get; set; }
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime WorkStart { get; set; }
        public string Description { get; set; }
    }
}
