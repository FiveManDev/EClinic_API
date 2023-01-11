namespace Project.IdentityService.Events.ProfileEvents
{
    public class UpdateProfileEvent
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
    }
}
