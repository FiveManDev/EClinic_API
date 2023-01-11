using Project.Data.Model;

namespace Project.IdentityService.Data
{
    public class Role : BaseEntity
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> User { get; set; }
    }
}
