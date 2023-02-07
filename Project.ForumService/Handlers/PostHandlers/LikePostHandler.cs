using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;
using Project.ForumService.Queries;

namespace Project.ForumService.Handlers.PostHandlers
{
    public class LikeCommentHandler : IRequestHandler<LikePostCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Post> repository;

        public LikeCommentHandler(IMongoDBRepository<Post> repository)
        {
            this.repository = repository;
        }

        public async Task<ObjectResult> Handle(LikePostCommands request, CancellationToken cancellationToken)
        {
            try
            {
                Post post = await repository.GetAsync(request.PostID);
                if (post == null)
                {
                    return ApiResponse.NotFound("Post Not Found.");
                }
                var userID = Guid.Parse(request.UserID);
                var result = post.LikeUserIds.Contains(userID);
                if (result)
                {
                    post.LikeUserIds.Remove(userID);
                }
                else
                {
                    post.LikeUserIds.Add(userID);
                }

                await repository.UpdateAsync(post);
                return ApiResponse.OK("Update Like Post Success");
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}
