using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;
using Project.ForumService.Dtos.PostsDtos;
using Project.ForumService.Queries;

namespace Project.ForumService.Handlers.PostHandlers
{
    public class UpdateCommentHandler : IRequestHandler<UpdatePostCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Post> repository;

        public UpdateCommentHandler(IMongoDBRepository<Post> repository)
        {
            this.repository = repository;
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
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}
