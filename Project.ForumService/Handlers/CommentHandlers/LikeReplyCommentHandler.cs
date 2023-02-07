using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;
using Project.ForumService.Queries;
using System.Xml.Linq;

namespace Project.ForumService.Handlers.CommentHandlers
{
    public class LikeReplyCommentHandler : IRequestHandler<LikeReplyCommentCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Comment> repository;

        public LikeReplyCommentHandler(IMongoDBRepository<Comment> repository)
        {
            this.repository = repository;
        }

        public async Task<ObjectResult> Handle(LikeReplyCommentCommands request, CancellationToken cancellationToken)
        {
            try
            {
                Comment comment = await repository.GetAsync(request.ParentCommentID);
                if (comment == null)
                {
                    return ApiResponse.NotFound("Parent Comment Not Found.");
                }
                var userID = Guid.Parse(request.UserID);
                foreach (ReplyComment replyComment in comment.ReplyComments)
                {
                    if (replyComment.Id == request.CommentID)
                    {
                        var result = replyComment.LikeUserIds.Contains(userID);
                        if (result)
                        {
                            replyComment.LikeUserIds.Remove(userID);
                        }
                        else
                        {
                            replyComment.LikeUserIds.Add(userID);
                        }
                    }
                }
                await repository.UpdateAsync(comment);
                return ApiResponse.OK("Update Like Comment Success");
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}
