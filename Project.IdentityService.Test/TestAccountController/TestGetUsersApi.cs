using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Project.Common.Paging;
using Project.IdentityService.Controllers;
using Project.IdentityService.Dtos;
using Project.IdentityService.Queries;
using Xunit;

namespace Project.IdentityService.Test.TestAccountController
{
    public class TestGetUsersApi
    {
        private readonly Mock<IMediator> mediatorMock;
        private readonly AccountController accountController;

        public TestGetUsersApi()
        {
            mediatorMock = new Mock<IMediator>();
            accountController = new AccountController(mediatorMock.Object);
        }

        [Fact]
        public async Task GetUsers_Should_Return_OkResult()
        {
            //Arrange
            var pageNumber = 1;
            var pageSize = 10;
            var searchUserDtos = new SearchUserDtos();
            var paginationRequestHeader = new PaginationRequestHeader { PageNumber = pageNumber, PageSize = pageSize };
            var response = new Mock<HttpResponse>();
            var query = new GetAllUserQuery(paginationRequestHeader, searchUserDtos, response.Object);
            mediatorMock.Setup(x => x.Send(query, CancellationToken.None))
                .ReturnsAsync(new OkObjectResult(It.IsAny<object>()))
                .Verifiable();

            //Act
            var result = await accountController.GetUsers(pageNumber, pageSize, searchUserDtos);

            //Assert
            mediatorMock.Verify();
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
