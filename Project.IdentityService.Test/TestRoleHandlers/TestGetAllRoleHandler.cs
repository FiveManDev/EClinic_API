using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Project.Common.Json;
using Project.Common.Paging;
using Project.Common.TestResponse;
using Project.IdentityService.Data;
using Project.IdentityService.Dtos;
using Project.IdentityService.Handlers.Account;
using Project.IdentityService.Handlers.Roles;
using Project.IdentityService.Mapper;
using Project.IdentityService.Queries;
using Project.IdentityService.Repository.RoleRepository;
using Project.IdentityService.Repository.UserRepository;
using Project.IdentityService.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project.IdentityService.Test.TestRoleHandlers
{
    [ExcludeFromCodeCoverage]
    public class TestGetAllRoleHandler
    {
        private readonly IMapper mapper;
        private readonly Mock<IRoleRepository> mockRepo;
        private readonly Mock<ILogger<GetAllRoleHandler>> mockLogger;
        public TestGetAllRoleHandler()
        {
            mockRepo = new Mock<IRoleRepository>();
            mockLogger = new Mock<ILogger<GetAllRoleHandler>>();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetRoles_Should_Return_OkResult()
        {   
            var handler = new GetAllRoleHandler( mockLogger.Object, mockRepo.Object, mapper);
            var query = new GetAllRoleQuery();

            var result = await handler.Handle(query, CancellationToken.None);
            var objectResult = Assert.IsType<ObjectResult>(result);
            var dataResponse = JsonHelper.ConvertObjectJson<ResultTypeData<List<GetUsersDtos>>>(objectResult.Value);

            Assert.NotNull(dataResponse);
            Assert.Equal(200, objectResult.StatusCode);
        }
        [Fact]
        public async Task GetRoles_Should_Return_InternalServerError()
        {
            mockRepo.Setup(r => r.GetAllAsync())
                .ThrowsAsync(new Exception("Test exaginationRequestHeader, searchUserDtosception"));
            var handler = new GetAllRoleHandler(mockLogger.Object, mockRepo.Object, mapper);
            var query = new GetAllRoleQuery();

            var result = await handler.Handle(query, CancellationToken.None);
            var objectResult = Assert.IsType<ObjectResult>(result);
            var dataResponse = JsonHelper.ConvertObjectJson<ResultTypeData<List<GetUsersDtos>>>(objectResult.Value);

            Assert.NotNull(dataResponse);
            Assert.Equal(500, objectResult.StatusCode);
        }
    }
}
