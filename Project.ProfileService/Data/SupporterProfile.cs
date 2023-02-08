namespace Project.ProfileService.Data
{
    public class SupporterProfile
    {
        public Guid ProfileID { get; set; }
        public DateTime WorkStart { get; set; }
        public string Description { get; set; }
        public Profile Profile { get; set; }
    }
}
