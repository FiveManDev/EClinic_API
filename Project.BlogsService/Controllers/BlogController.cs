using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BlogService.Commands;
using Project.BlogService.Dtos.BlogDtos;
using Project.BlogService.Dtos.BlogsDtos;
using Project.BlogService.Queries;
using Project.Common.Constants;
using Project.Common.Paging;
using Project.Core.Authentication;

namespace Project.BlogService.Controllers;

[Route("api/v{version:apiVersion}/[controller]/[Action]")]
[ApiController]
[ApiVersion("1")]
public class BlogController : ControllerBase
{
    private readonly IMediator mediator;

    public BlogController(IMediator mediator)
    {
        this.mediator = mediator;
    }
   
    [HttpPost]
    [CustomAuthorize(Authorities = new[] { RoleConstants.Admin, RoleConstants.Supporter })]
    public async Task<IActionResult> CreateBlog([FromForm] CreateBlogDtos createBlogDtos)
    {
        string userId = User.Claims.FirstOrDefault(claim => claim.Type == "UserID").Value;
        return await mediator.Send(new CreateBlogCommands(createBlogDtos, userId));
    }

    [HttpPut]
    [CustomAuthorize(Authorities = new[] { RoleConstants.Admin, RoleConstants.Supporter })]
    public async Task<IActionResult> UpdatePost([FromForm] UpdateBlogDtos updateBlogDtos)
    {
        return await mediator.Send(new UpdateBlogCommands(updateBlogDtos));
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogByID(Guid BlogID)
    {
        return await mediator.Send(new GetBlogQuery(BlogID));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBlog([FromHeader] int PageNumber, [FromHeader] int PageSize)
    {
        PaginationRequestHeader paginationRequestHeader = new PaginationRequestHeader { PageSize = PageSize, PageNumber = PageNumber };
        return await mediator.Send(new GetAllBlogQuery(paginationRequestHeader, Response));
    }

    [HttpDelete]
    [CustomAuthorize(Authorities = new[] { RoleConstants.Admin, RoleConstants.Supporter })]
    public async Task<IActionResult> DeleteBlogByID(Guid BlogID)
    {
        return await mediator.Send(new DeleteBlogCommands(BlogID));
    }

    [HttpGet]
    public async Task<IActionResult> SearchBlog([FromHeader] int PageNumber, [FromHeader] int PageSize, [FromQuery] SearchBlogDtos SearchBlogDtos)
    {
        PaginationRequestHeader paginationRequestHeader = new PaginationRequestHeader { PageSize = PageSize, PageNumber = PageNumber };
        return await mediator.Send(new GetBlogsQuery(paginationRequestHeader, SearchBlogDtos, Response));
    }

}
