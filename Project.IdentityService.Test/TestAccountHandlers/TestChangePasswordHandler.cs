using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Project.Common.Json;
using Project.Common.TestResponse;
using Project.IdentityService.Commands;
using Project.IdentityService.Data;
using Project.IdentityService.Dtos;
using Project.IdentityService.Handlers.Account;
using Project.IdentityService.Repository.UserRepository;
using Project.IdentityService.Test.Mocks;
using System.Linq.Expressions;
using Xunit;
using Xunit.Sdk;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Project.IdentityService.Test.TestAccountHandler
{
    public class TestChangePasswordHandler
    {
        private readonly Mock<IUserRepository> mockRepo;
        private readonly Mock<ILogger<ChangePasswordHandler>> mockLogger;
        public TestChangePasswordHandler()
        {
            mockRepo = MockUserRepository.GetUserRepository();
            mockLogger = new Mock<ILogger<ChangePasswordHandler>>();
        }

        [Fact]
        public async Task ChangePassword_Should_Return_OkResult()
        {
            FakeData data = new FakeData();
            var users = data.GetUsers();
            var UserID = users[0].UserID;
            var changePassword = new ChangePasswordDtos { NewPassword = "1234567", ConfirmPassword = "1234567", OldPassword = "123456789" };
            mockRepo.Setup(r => r.GetAsync(UserID))
                .ReturnsAsync(users[0]);

            var command = new ChangePasswordCommand(changePassword, UserID.ToString());
            var handler = new ChangePasswordHandler(mockRepo.Object, mockLogger.Object);
            var result = await handler.Handle(command, CancellationToken.None);
            var dataResponse = JsonHelper.ConvertObjectJson<ResultTypeMessage>(result.Value);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(dataResponse);
            Assert.True(dataResponse.IsSuccess);

        }
        [Fact]
        public async Task ChangePassword_Should_Return_BadRequestResult()
        {
            FakeData data = new FakeData();
            var users = data.GetUsers();
            var UserID = users[0].UserID;
            var changePassword = new ChangePasswordDtos { NewPassword = "1234567", ConfirmPassword = "123456@7", OldPassword = "123456789" };
            mockRepo.Setup(r => r.GetAsync(UserID))
                .ReturnsAsync(users[0]);

            var command = new ChangePasswordCommand(changePassword, UserID.ToString());
            var handler = new ChangePasswordHandler(mockRepo.Object, mockLogger.Object);
            var result = await handler.Handle(command, CancellationToken.None);
            var dataResponse = JsonHelper.ConvertObjectJson<ResultTypeMessage>(result.Value);
            Assert.Equal(400, result.StatusCode);
            Assert.NotNull(dataResponse);
            Assert.False(dataResponse.IsSuccess);

        }
        [Fact]
        public async Task ChangePassword_Should_Return_InternalServerErrorResult()
        {
            FakeData data = new FakeData();
            var users = data.GetUsers();
            var UserID = users[0].UserID;
            
            var changePassword = new ChangePasswordDtos { NewPassword = "1234567", ConfirmPassword = "1234567", OldPassword = "123456789" };
            mockRepo.Setup(r => r.GetAsync(UserID))
                .ReturnsAsync(users[0]);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<User>())).ReturnsAsync((User User) =>
            {
                users.Remove(User);
                users.Add(User);
                return false;
            });
            var command = new ChangePasswordCommand(changePassword, UserID.ToString());
            var handler = new ChangePasswordHandler(mockRepo.Object, mockLogger.Object);
            var result = await handler.Handle(command, CancellationToken.None);
            var dataResponse = JsonHelper.ConvertObjectJson<ResultTypeMessage>(result.Value);
            Assert.Equal(500, result.StatusCode);
            Assert.NotNull(dataResponse);
            Assert.False(dataResponse.IsSuccess);

        }
        [Fact]
        public async Task ChangePassword_Should_Return_IncorrectPasswordErrorResult()
        {
            FakeData data = new FakeData();
            var users = data.GetUsers();
            var UserID = users[0].UserID;

            var changePassword = new ChangePasswordDtos { NewPassword = "1234567", ConfirmPassword = "1234567", OldPassword = "123456" };
            mockRepo.Setup(r => r.GetAsync(UserID))
                .ReturnsAsync(users[0]);
            var command = new ChangePasswordCommand(changePassword, UserID.ToString());
            var handler = new ChangePasswordHandler(mockRepo.Object, mockLogger.Object);
            var result = await handler.Handle(command, CancellationToken.None);
            var dataResponse = JsonHelper.ConvertObjectJson<ResultTypeMessage>(result.Value);
            Assert.Equal(400, result.StatusCode);
            Assert.NotNull(dataResponse);
            Assert.False(dataResponse.IsSuccess);

        }
        [Fact]
        public async Task ChangePassword_Should_Return_InternalServerErrorWhenGetResult()
        {
            FakeData data = new FakeData();
            var users = data.GetUsers();
            var UserID = users[0].UserID;

            var changePassword = new ChangePasswordDtos { NewPassword = "1234567", ConfirmPassword = "1234567", OldPassword = "123456789" };
            mockRepo.Setup(r => r.GetAsync(UserID))
                .ThrowsAsync(new Exception("Test exception"));
            var command = new ChangePasswordCommand(changePassword, UserID.ToString());
            var handler = new ChangePasswordHandler(mockRepo.Object, mockLogger.Object);
            var result = await handler.Handle(command, CancellationToken.None);
            var dataResponse = JsonHelper.ConvertObjectJson<ResultTypeMessage>(result.Value);
            Assert.Equal(500, result.StatusCode);
            Assert.NotNull(dataResponse);
            Assert.False(dataResponse.IsSuccess);

        }
    }
}
