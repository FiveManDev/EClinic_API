using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Project.ForumService.Queries
{

    public record GetAllPostQuery() : IRequest<ObjectResult>;
    public record GetPostQuery(Guid PostID, string UserID) : IRequest<ObjectResult>;
    public record GetAnswerQuery(Guid PostID, string UserID) : IRequest<ObjectResult>;
    public record GetAllCommentQuery(Guid PostID, string UserID) : IRequest<ObjectResult>;
}
