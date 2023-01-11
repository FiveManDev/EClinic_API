using Project.Data.Model;

namespace Project.IdentityService.Data
{
    public class Token : BaseEntity
    {
        public Guid TokenID { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
    }
}
