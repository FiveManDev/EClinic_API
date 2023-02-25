using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;

namespace Project.ForumService.Queries
{

    public record GetAllPostQuery() : IRequest<ObjectResult>;
    public record GetPostQuery(Guid PostID, string UserID) : IRequest<ObjectResult>;
    public record GetAnswerQuery(Guid PostID, string UserID) : IRequest<ObjectResult>;
    public record GetAllCommentQuery(Guid PostID, string UserID) : IRequest<ObjectResult>;
    public record GetAllHashtagQuery() : IRequest<ObjectResult>;
    public record GetPostsQuery(PaginationRequestHeader PaginationRequestHeader, string SearchText,HttpResponse Response) : IRequest<ObjectResult>;
}
