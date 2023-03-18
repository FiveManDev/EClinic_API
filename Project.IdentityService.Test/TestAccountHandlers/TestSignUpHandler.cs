using Castle.Core.Configuration;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using Project.IdentityService.Commands;
using Project.IdentityService.Data;
using Project.IdentityService.Dtos;
using Project.IdentityService.Handlers.Account;
using Project.IdentityService.Protos;
using Project.IdentityService.Repository.UserRepository;
using Project.IdentityService.Test.Mocks;
using System.Linq.Expressions;
using Xunit;

namespace Project.IdentityService.Test.TestAccountController
{
    public class TestSignUpHandler
    {
        private readonly Mock<IUserRepository> userRepositoryMock;
        private readonly Mock<Microsoft.Extensions.Configuration.IConfiguration> configurationMock;
        private readonly Mock<ILogger<SignUpHandler>> loggerMock;
        private readonly Mock<ProfileService.ProfileServiceClient> profileServiceClientMock;

        public TestSignUpHandler()
        {
            userRepositoryMock = new Mock<IUserRepository>();
            configurationMock = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            var expectedUrl = "https://example.com";
            var section = new Mock<IConfigurationSection>();
            section.Setup(x => x.Value).Returns(expectedUrl);
            configurationMock.Setup(x => x.GetSection("GrpcSettings:ProfileServiceUrl")).Returns(section.Object);
            loggerMock = new Mock<ILogger<SignUpHandler>>();
            profileServiceClientMock = new Mock<ProfileService.ProfileServiceClient>();
            
        }

        [Fact]
        public async Task SignUp_WithValidData_ReturnsInternalServerError()
        {
            FakeData data = new FakeData();
            var user = data.GetUsers().First();
            var signUpCommand = new SignUpCommand
            (
                 new SignUpDtos
                 {
                     UserName = "testuser",
                     Password = "testpassword",
                     ConfirmPassword = "testpassword",
                     Email = "testuser@example.com",
                     FirstName = "Test",
                     LastName = "User",
                     Gender = true,
                     DateOfBirth = DateTime.UtcNow.Date.AddYears(-25)
                 }
            );

            try
            {
                profileServiceClientMock.Setup(x => x.EmailIsExistAsync(It.IsAny<CheckEmailRequest>(), null, null, CancellationToken.None))
                  .Returns((CheckEmailRequest request, CallOptions options, Metadata metadata, CancellationToken cancellationToken) =>
                  {
                      var response = new EmailExistResponse { IsExist = true };
                      var result = Task.FromResult(response);
                      return new AsyncUnaryCall<EmailExistResponse>(result, Task.FromResult(metadata), () => Status.DefaultSuccess, () => new Metadata(), () => { });
                  });



            }
            catch {  }
            userRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(false);
            userRepositoryMock.Setup(x => x.CreateEntityAsync(It.IsAny<User>())).ReturnsAsync(user);
            SignUpHandler signUpHandler = new SignUpHandler(userRepositoryMock.Object, configurationMock.Object, loggerMock.Object);
            // Act
            var result = await signUpHandler.Handle(signUpCommand, CancellationToken.None);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }
        [Fact]
        public async Task SignUp_WithValidData_ReturnsBadRequestUserExist()
        {
            FakeData data = new FakeData();
            var user = data.GetUsers().First();
            var signUpCommand = new SignUpCommand
            (
                 new SignUpDtos
                 {
                     UserName = "testuser",
                     Password = "testpassword",
                     ConfirmPassword = "testpassword",
                     Email = "testuser@example.com",
                     FirstName = "Test",
                     LastName = "User",
                     Gender = true,
                     DateOfBirth = DateTime.UtcNow.Date.AddYears(-25)
                 }
            );

            userRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(true);
            userRepositoryMock.Setup(x => x.CreateEntityAsync(It.IsAny<User>())).ReturnsAsync(user);
            SignUpHandler signUpHandler = new SignUpHandler(userRepositoryMock.Object, configurationMock.Object, loggerMock.Object);
            // Act
            var result = await signUpHandler.Handle(signUpCommand, CancellationToken.None);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, objectResult.StatusCode);
        }
        [Fact]
        public async Task SignUp_WithValidData_ReturnsBadRequestPasswordNotTheSame()
        {
            FakeData data = new FakeData();
            var user = data.GetUsers().First();
            var signUpCommand = new SignUpCommand
            (
                 new SignUpDtos
                 {
                     UserName = "testuser",
                     Password = "testpassword",
                     ConfirmPassword = "testpassword123",
                     Email = "testuser@example.com",
                     FirstName = "Test",
                     LastName = "User",
                     Gender = true,
                     DateOfBirth = DateTime.UtcNow.Date.AddYears(-25)
                 }
            );

            userRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(false);
            userRepositoryMock.Setup(x => x.CreateEntityAsync(It.IsAny<User>())).ReturnsAsync(user);
            SignUpHandler signUpHandler = new SignUpHandler(userRepositoryMock.Object, configurationMock.Object, loggerMock.Object);
            // Act
            var result = await signUpHandler.Handle(signUpCommand, CancellationToken.None);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, objectResult.StatusCode);
        }
    }
}
