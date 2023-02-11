using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Logger;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;

namespace Project.ForumService.Handlers.PostHandlers
{
    public class UpdateCommentHandler : IRequestHandler<UpdatePostCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Post> repository;
        private readonly ILogger<UpdateCommentHandler> logger;
        public UpdateCommentHandler(IMongoDBRepository<Post> repository, ILogger<UpdateCommentHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(UpdatePostCommands request, CancellationToken cancellationToken)
        {
            try
            {
                Post post = await repository.GetAsync(request.updatePostDtos.PostID);
                if (post == null)
                {
                    return ApiResponse.NotFound("Post not found");
                }
                post.Title = request.updatePostDtos.Title;
                post.Content = request.updatePostDtos.Content;
                post.UpdatedAt = DateTime.Now;
                // Sử lý lưu image
                await repository.UpdateAsync(post);
                return ApiResponse.OK("Update Post Success.");
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
