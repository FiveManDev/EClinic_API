using Microsoft.Extensions.Logging;
using Moq;
using Project.Common.Constants;
using Project.IdentityService.Commands;
using Project.IdentityService.Data;
using Project.IdentityService.Handlers.Account;
using Project.IdentityService.Repository.UserRepository;
using Project.IdentityService.Test.Mocks;
using Xunit;

namespace Project.IdentityService.Test.TestAccountHandler
{
    public class TestCreateUserHandler 
    {
        private readonly Mock<IUserRepository> mockRepo;
        private readonly Mock<ILogger<CreateUserHandler>> mockLogger;
        private readonly CreateUserHandler handler;
        public TestCreateUserHandler()
        {
            mockRepo = MockUserRepository.GetUserRepository();
            mockLogger = new Mock<ILogger<CreateUserHandler>>();
            handler = new CreateUserHandler(mockRepo.Object, mockLogger.Object);
        }
        [Fact]
        public async Task CreateUsersWithUserRole_Should_Return_Guid()
        {
            var email = "usertest@gmail.com";
            var role = RoleConstants.User;
            var command = new CreateUserCommand(email, role);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.IsType<Guid>(result);
        }
        [Fact]
        public async Task CreateUsersWithSupporterRole_Should_Return_Guid()
        {
            var email = "supportertest@gmail.com";
            var role = RoleConstants.Supporter;
            var command = new CreateUserCommand(email, role);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.IsType<Guid>(result);
        }
        [Fact]
        public async Task CreateUsersWithAdminRole_Should_Return_Guid()
        {
            var email = "admintest@gmail.com";
            var role = RoleConstants.Admin;
            var command = new CreateUserCommand(email, role);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.IsType<Guid>(result);
        }
        [Fact]
        public async Task CreateUsersWithExpertRole_Should_Return_Guid()
        {
            var email = "experttest@gmail.com";
            var role = RoleConstants.Expert;
            var command = new CreateUserCommand(email, role);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.IsType<Guid>(result);
        }
        [Fact]
        public async Task CreateUsersWithDoctorRole_Should_Return_Guid()
        {
            var email = "doctortest@gmail.com";
            var role = RoleConstants.Doctor;
            var command = new CreateUserCommand(email, role);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.IsType<Guid>(result);
        }
        [Fact]
        public async Task CreateUsers_Should_Return_Error()
        {
            var email = "doctortest@gmail.com";
            var role = RoleConstants.Doctor;
            mockRepo.Setup(r => r.CreateEntityAsync(It.IsAny<User>())).ThrowsAsync(new Exception("Test exception"));
            var command = new CreateUserCommand(email, role);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.IsType<Guid>(result);
        }
        [Fact]
        public async Task CreateUsersFalse_Should_Return_Error()
        {
            var email = "doctortest@gmail.com";
            var role = RoleConstants.Doctor;
            mockRepo.Setup(r => r.CreateEntityAsync(It.IsAny<User>())).ReturnsAsync((User)null);
            var command = new CreateUserCommand(email, role);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.IsType<Guid>(result);
        }
    }
}
