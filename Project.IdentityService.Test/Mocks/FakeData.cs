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
                    UserID = Guid.Parse("0c2474d7-2c51-42b7-baa6-57253f372ced"),
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
                    UserID = Guid.Parse("cb413839-e72a-4787-b5fc-a0293e1e1195"),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDAdmin,
                    UserName = "Test57123",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.Parse("24ead331-e327-4902-81a1-d5c222fdfdd4"),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDSupporter,
                    UserName = "Test48123",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.Parse("3249d1ec-a6ab-493f-b351-894fcec8e547"),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDUser,
                    UserName = "Test12783",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.Parse("6c70ee77-061f-4ebb-8fc8-58662092209f"),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDDoctor,
                    UserName = "Test14223",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.Parse("4898c31c-7643-4b47-93f1-3d335bbee4d1"),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDDoctor,
                    UserName = "Test17523",
                    UpdatedAt = DateTime.Now
                },new User
                {
                    UserID = Guid.Parse("998605ff-910b-4136-9fb5-6ec4a1ba33d6"),
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
                    UserID = Guid.Parse("3fdecf58-d7f5-4693-91bf-a3d9a0e90221"),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDAdmin,
                    UserName = "AdminTest57123",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.Parse("5f78e301-7246-44eb-bb9d-fdd933ab702e"),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDSupporter,
                    UserName = "SupporterTest48123",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.Parse("d5231735-6758-498f-a54f-2cf897cf3e2e"),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDUser,
                    UserName = "UserTest12783",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.Parse("20942139-fd8c-42e8-97f3-54660feda530"),
                    CreatedAt = DateTime.Now,
                    Enabled = true,
                    PasswordHash =pass.Hash,
                    PasswordSalt = pass.Salt,
                    RoleID = RoleConstants.IDDoctor,
                    UserName = "DoctorTest14223",
                    UpdatedAt = DateTime.Now
                }, new User
                {
                    UserID = Guid.Parse("17c873af-3ea9-4e7d-837c-194d59ac8ad0"),
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
