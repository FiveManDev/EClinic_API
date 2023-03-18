using Microsoft.Extensions.Logging;
using Moq;
using Project.Common.Constants;
using Project.IdentityService.Commands;
using Project.IdentityService.Data;
using Project.IdentityService.Handlers.Account;
using Project.IdentityService.Queries;
using Project.IdentityService.Repository.UserRepository;
using Project.IdentityService.Test.Mocks;
using System.Linq.Expressions;
using Xunit;

namespace Project.IdentityService.Test.TestAccountHandler
{
    public class TestGetAllUserWithRoleHandler 
    {
        private readonly Mock<IUserRepository> mockRepo;
        private readonly Mock<ILogger<GetAllUserWithRoleHandler>> mockLogger;
        private readonly GetAllUserWithRoleHandler handler;
        public TestGetAllUserWithRoleHandler()
        {
            mockRepo = MockUserRepository.GetUserRepository();
            mockLogger = new Mock<ILogger<GetAllUserWithRoleHandler>>();
            handler = new GetAllUserWithRoleHandler(mockRepo.Object, mockLogger.Object);
        }
        [Fact]
        public async Task CreateUsersWithUserRole_Should_Return_Guid()
        {
            var role = RoleConstants.User;
            var command = new GetAllUserWithRoleQuery(role);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.IsType<List<Guid>>(result);
        }
        [Fact]
        public async Task CreateUsersWithSupporterRole_Should_Return_Guid()
        {
            var role = RoleConstants.Supporter;
            var command = new GetAllUserWithRoleQuery(role);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.IsType<List<Guid>>(result);
        }
        [Fact]
        public async Task CreateUsersWithAdminRole_Should_Return_Guid()
        {
            var role = RoleConstants.Admin;
            var command = new GetAllUserWithRoleQuery(role);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.IsType<List<Guid>>(result);
        }
        [Fact]
        public async Task CreateUsersWithExpertRole_Should_Return_Guid()
        {
            var role = RoleConstants.Expert;
            var command = new GetAllUserWithRoleQuery(role);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.IsType<List<Guid>>(result);
        }
        [Fact]
        public async Task CreateUsersWithDoctorRole_Should_Return_Guid()
        {
            var role = RoleConstants.Doctor;
            var command = new GetAllUserWithRoleQuery(role);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.IsType<List<Guid>>(result);
        }
        [Fact]
        public async Task CreateUsers_Should_Return_Error()
        {
            var role = RoleConstants.Doctor;
            mockRepo.Setup(r => r.GetAllAsync(It.IsAny<Expression<Func<User, bool>>>())).ThrowsAsync(new Exception("Test exception"));
            var command = new GetAllUserWithRoleQuery(role);
            var result = await handler.Handle(command, CancellationToken.None);
            Assert.IsType<List<Guid>>(result);
        }
    }
}
