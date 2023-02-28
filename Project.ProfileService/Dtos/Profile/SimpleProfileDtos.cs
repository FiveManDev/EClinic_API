namespace Project.ProfileService.Dtos.Profile
{
    public class SimpleProfileDtos
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string AvatarKey { get; set; }
    }
}
