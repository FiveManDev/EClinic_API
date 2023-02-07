using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;

namespace Project.ForumService.Handlers.CommentHandlers
{
    public class DeleteReplyCommentHandler : IRequestHandler<DeleteReplyCommentCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Comment> repository;

        public DeleteReplyCommentHandler(IMongoDBRepository<Comment> repository)
        {
            this.repository = repository;
        }

        public async Task<ObjectResult> Handle(DeleteReplyCommentCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var comment = await repository.GetAsync(request.ParentCommentID);
                if (comment == null)
                {
                    return ApiResponse.BadRequest("Parent Comment Not Found");
                }
                var replyComment = comment.ReplyComments.SingleOrDefault(r=>r.Id == request.CommentID);
                if (replyComment == null)
                {
                    return ApiResponse.NotFound("Comment Not Found");
                }
                comment.ReplyComments.Remove(replyComment);
                await repository.UpdateAsync(comment);
                return ApiResponse.OK("Delete Comment Success.");
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}
