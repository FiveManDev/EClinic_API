using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;

namespace Project.ForumService.Handlers.CommentHandlers
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Comment> repository;

        public DeleteCommentHandler(IMongoDBRepository<Comment> repository)
        {
            this.repository = repository;
        }

        public async Task<ObjectResult> Handle(DeleteCommentCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await repository.GetAsync(request.CommentID);
                if (result == null)
                {
                    return ApiResponse.BadRequest("Comment Not Found");
                }
                await repository.RemoveAsync(request.CommentID);
                return ApiResponse.OK("Delete Comment Success.");
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}
