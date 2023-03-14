using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Project.Common.Constants;
using Project.Common.Json;
using Project.Common.Paging;
using Project.Common.Security;
using Project.Common.TestResponse;
using Project.IdentityService.Data;
using Project.IdentityService.Dtos;
using Project.IdentityService.Handlers.Account;
using Project.IdentityService.Mapper;
using Project.IdentityService.Queries;
using Project.IdentityService.Repository.UserRepository;
using Project.IdentityService.Test.Mocks;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Project.IdentityService.Test.TestAccountController
{
    [ExcludeFromCodeCoverage]
    public class TestGetUsersHandler
    {
        private readonly IMapper mapper;
        private readonly Mock<IUserRepository> mockRepo;
        private readonly Mock<ILogger<GetUsersHandler>> mockLogger;
        public TestGetUsersHandler()
        {
            mockRepo = new Mock<IUserRepository>();
            mockLogger = new Mock<ILogger<GetUsersHandler>>();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetUsers_Should_Return_OkResult()
        {
            FakeData data = new FakeData();
            var users = data.GetUsers();

            var pageNumber = 1;
            var pageSize = 10;
            PaginationRequestHeader paginationRequestHeader = new PaginationRequestHeader { PageSize = pageSize, PageNumber = pageNumber };
            var searchUserDtos = new SearchUserDtos();
            PaginationResponseHeader PaginationResponseHeader = new PaginationResponseHeader { PageIndex = pageNumber, PageSize = pageSize, TotalCount = users.Count };
            var paginationData = users.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            mockRepo.Setup(r => r.GetUsersAsync(paginationRequestHeader, searchUserDtos))
                .ReturnsAsync(new PaginationModel<List<User>> { PaginationResponseHeader = PaginationResponseHeader, PaginationData = paginationData });
            var handler = new GetUsersHandler(mockRepo.Object, mockLogger.Object, mapper);
            var query = new GetAllUserQuery(paginationRequestHeader, searchUserDtos, new DefaultHttpContext().Response);

            var result = await handler.Handle(query, CancellationToken.None);
            var objectResult = Assert.IsType<ObjectResult>(result);
            var dataResponse = JsonHelper.ConvertObjectJson<ResultTypeData<List<GetUsersDtos>>>(objectResult.Value);
            var httpResponse = query.Response;
            var headerValue = httpResponse.Headers["X-Pagination"];
            var paginationHeader = JsonConvert.DeserializeObject<PaginationResponseHeader>(httpResponse.Headers["X-Pagination"]);

            Assert.NotNull(dataResponse);
            Assert.Equal(200, objectResult.StatusCode);
            Assert.True(dataResponse.IsSuccess);
            Assert.False(string.IsNullOrEmpty(headerValue));
            Assert.Equal(users.Count(), paginationHeader.TotalCount);
            Assert.Equal(pageSize, paginationHeader.PageSize);
            Assert.Equal(pageNumber, paginationHeader.PageIndex);
        }
    }
}