using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.ForumService.Dtos.AnswersDtos;
using Project.ForumService.Dtos.CommentsDtos;
using Project.ForumService.Dtos.PostsDtos;

namespace Project.ForumService.Commands
{
    #region PostCommands
    public record CreatePostCommands(CreatePostDtos createPostDtos) : IRequest<ObjectResult>;
    public record UpdatePostCommands(UpdatePostDtos updatePostDtos) : IRequest<ObjectResult>;
    public record DeletePostCommands(Guid PostID) : IRequest<ObjectResult>;
    public record LikePostCommands(Guid PostID, string UserID) : IRequest<ObjectResult>;
    #endregion
    #region AnswerCommands
    public record CreateAnswerCommands(CreateAnswerDtos CreateAnswerDtos) : IRequest<ObjectResult>;
    public record UpdateAnswerCommands(UpdateAnswerDtos UpdateAnswerDtos) : IRequest<ObjectResult>;
    public record DeleteAnswerCommands(Guid AnswerID) : IRequest<ObjectResult>;
    public record LikeAnswerCommands(Guid AnswerID, string UserID) : IRequest<ObjectResult>;
    #endregion
    #region CommentCommands
    public record CreateCommentCommands(CreateCommentDtos CreateCommentDtos) : IRequest<ObjectResult>;
    public record CreateReplyCommentCommands(CreateReplyCommentDtos CreateReplyCommentDtos) : IRequest<ObjectResult>;
    public record UpdateCommentCommands(UpdateCommentDtos UpdateCommentDtos) : IRequest<ObjectResult>;
    public record UpdateReplyCommentCommands(UpdateReplyCommentDtos UpdateReplyCommentDtos) : IRequest<ObjectResult>;
    public record DeleteCommentCommands(Guid CommentID) : IRequest<ObjectResult>;
    public record DeleteReplyCommentCommands(Guid ParentCommentID, Guid CommentID) : IRequest<ObjectResult>;
    public record LikeCommentCommands(Guid CommentID, string UserID) : IRequest<ObjectResult>;
    public record LikeReplyCommentCommands(Guid ParentCommentID, Guid CommentID, string UserID) : IRequest<ObjectResult>;
    #endregion
}
