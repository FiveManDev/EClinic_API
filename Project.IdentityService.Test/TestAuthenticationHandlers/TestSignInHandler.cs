//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//using Moq;
//using Project.Common.Json;
//using Project.Common.Paging;
//using Project.Common.TestResponse;
//using Project.Core.Authentication;
//using Project.Core.Model;
//using Project.IdentityService.Commands;
//using Project.IdentityService.Data;
//using Project.IdentityService.Dtos;
//using Project.IdentityService.Handlers.Account;
//using Project.IdentityService.Mapper;
//using Project.IdentityService.Queries;
//using Project.IdentityService.Repository.RoleRepository;
//using Project.IdentityService.Repository.UserRepository;
//using Project.IdentityService.Test.Mocks;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq.Expressions;
//using Xunit;

//namespace Project.IdentityService.Handlers.Authentication
//{
//    [ExcludeFromCodeCoverage]
//    public class TestSignInHandler
//    {
//        private readonly Mock<IUserRepository> mockUserRepo;
//        private readonly Mock<IRoleRepository> mockRoleRepo;
//        private readonly Mock<ILogger<SignInHandler>> mockLogger;
//        public TestSignInHandler()
//        {
//            mockUserRepo = new Mock<IUserRepository>();
//            mockRoleRepo = new Mock<IRoleRepository>();
//            mockLogger = new Mock<ILogger<SignInHandler>>();
//        }
//        [Fact]
//        public async Task SignIn_Should_Return_OkResult()
//        {
//            FakeData data = new FakeData();
//            var users = data.GetUsers();
//            var roles = data.GetRoles();
//            var userName = "Test12783";
//            var password = "123456789";
//            SignInDtos signInDtos = new SignInDtos { UserName = userName, Password = password };
//            var user = users.SingleOrDefault(x => x.UserName == userName);
//            var role = roles.SingleOrDefault(x => x.RoleID == user.RoleID);
//            mockUserRepo.Setup(r => r.GetAsync(It.IsAny<Expression<Func<User, bool>>>()))
//                .ReturnsAsync(user);
//            mockRoleRepo.Setup(r => r.GetAsync(It.IsAny<Expression<Func<Role, bool>>>()))
//               .ReturnsAsync(role);
//            IConfiguration configuration = new ConfigurationBuilder()
//                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                .Build();
//            var handler = new SignInHandler(mockUserRepo.Object, mockRoleRepo.Object, mockLogger.Object);
//            var query = new SignInCommand(signInDtos);

//            var result = await handler.Handle(query, CancellationToken.None);
//            var objectResult = Assert.IsType<ObjectResult>(result);
//            var dataResponse = JsonHelper.ConvertObjectJson<TokenModel>(objectResult.Value);

//            Assert.NotNull(dataResponse);
//            Assert.Equal(200, objectResult.StatusCode);
//        }
//    }
//}
