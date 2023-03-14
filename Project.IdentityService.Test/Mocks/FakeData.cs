using Project.Common.Constants;
using Project.Common.Security;
using Project.IdentityService.Data;

namespace Project.IdentityService.Test.Mocks
{
    public class FakeData
    {
        private readonly HashSalt pass = Cryptography.EncryptPassword("123456789");
        public List<User> GetUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    UserID = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDDoctor,
                    UserName = "Test123",
                    UpdatedAt = DateTime.Now
                },
                 new User
                {
                    UserID = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDAdmin,
                    UserName = "Test57123",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDSupporter,
                    UserName = "Test48123",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDUser,
                    UserName = "Test12783",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDDoctor,
                    UserName = "Test14223",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDDoctor,
                    UserName = "Test17523",
                    UpdatedAt = DateTime.Now
                },new User
                {
                    UserID = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDDoctor,
                    UserName = "DoctorTest123",
                    UpdatedAt = DateTime.Now
                },
                 new User
                {
                    UserID = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDAdmin,
                    UserName = "AdminTest57123",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDSupporter,
                    UserName = "SupporterTest48123",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDUser,
                    UserName = "UserTest12783",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDDoctor,
                    UserName = "DoctorTest14223",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDDoctor,
                    UserName = "HahaTest17523",
                    UpdatedAt = DateTime.Now
                }
            };
            return users;
        }
        public List<Role> GetRoles()
        {
            var roles = new List<Role>
            {
                new Role { RoleID = RoleConstants.IDAdmin, RoleName = RoleConstants.Admin },
                new Role { RoleID = RoleConstants.IDSupporter, RoleName = RoleConstants.Supporter },
                new Role { RoleID = RoleConstants.IDDoctor, RoleName = RoleConstants.Doctor },
                new Role { RoleID = RoleConstants.IDUser, RoleName = RoleConstants.User },
                new Role { RoleID = RoleConstants.IDExpert, RoleName = RoleConstants.Expert }
            };
            return roles;
        }
    }
}
