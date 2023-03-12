using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Constants;
using Project.Common.Paging;
using Project.Core.Authentication;
using Project.ForumService.Commands;
using Project.ForumService.Dtos.PostsDtos;
using Project.ForumService.Queries;

namespace Project.ForumService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class PostController : ControllerBase
    {
        private readonly IMediator mediator;

        public PostController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetPosts([FromHeader] int PageNumber, [FromHeader] int PageSize, [FromQuery] string searchText)
        {
            PaginationRequestHeader paginationRequestHeader = new PaginationRequestHeader { PageSize = PageSize, PageNumber = PageNumber };
            return await mediator.Send(new GetPostsQuery(paginationRequestHeader, searchText, Response));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPost([FromHeader] int PageNumber, [FromHeader] int PageSize)
        {
            PaginationRequestHeader paginationRequestHeader = new PaginationRequestHeader { PageSize = PageSize, PageNumber = PageNumber };
            return await mediator.Send(new GetAllPostQuery(paginationRequestHeader, Response));
        }
        [HttpGet]
        public async Task<IActionResult> GetPostByID(Guid PostID)
        {
            string userId = User.Claims.FirstOrDefault(claim => claim.Type == "UserID")?.Value;
            return await mediator.Send(new GetPostQuery(PostID, userId));
        }
        [HttpPost]
        [CustomAuthorize(Authorities = new[] { RoleConstants.User, RoleConstants.Admin, RoleConstants.Supporter })]
        public async Task<IActionResult> CreatePost([FromForm] CreatePostDtos createPostDtos)
        {
            string userId = User.Claims.FirstOrDefault(claim => claim.Type == "UserID").Value;
            return await mediator.Send(new CreatePostCommands(createPostDtos, userId));
        }
        [HttpPut]
        [CustomAuthorize(Authorities = new[] { RoleConstants.User, RoleConstants.Admin, RoleConstants.Supporter })]
        public async Task<IActionResult> UpdatePost([FromForm] UpdatePostDtos updatePostDtos)
        {
            return await mediator.Send(new UpdatePostCommands(updatePostDtos));
        }
        [HttpDelete]
        [CustomAuthorize(Authorities = new[] { RoleConstants.User, RoleConstants.Admin, RoleConstants.Supporter })]
        public async Task<IActionResult> DeletePostByID(Guid PostID)
        {
            return await mediator.Send(new DeletePostCommands(PostID));
        }
        [HttpPut]
        [CustomAuthorize(Authorities = new[] { RoleConstants.User, RoleConstants.Admin, RoleConstants.Supporter, RoleConstants.Doctor })]
        public async Task<IActionResult> LikePost(Guid PostID)
        {
            string userId = User.Claims.FirstOrDefault(claim => claim.Type == "UserID").Value;
            return await mediator.Send(new LikePostCommands(PostID, userId));
        }
        [HttpPut]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Supporter, RoleConstants.Admin })]
        public async Task<IActionResult> ChangeActivePost(Guid PostID)
        {
            return await mediator.Send(new AcceptPostCommands(PostID));
        }
    }
}
