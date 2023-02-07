using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;

namespace Project.ForumService.Handlers.PostHandlers
{
    public class CreateCommentHandler : IRequestHandler<CreatePostCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Post> repository;
        private readonly IMapper mapper;

        public CreateCommentHandler(IMongoDBRepository<Post> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ObjectResult> Handle(CreatePostCommands request, CancellationToken cancellationToken)
        {
            try
            {
                Post post = mapper.Map<Post>(request.createPostDtos);
                post.CreatedAt = DateTime.Now;
                post.UpdatedAt = DateTime.Now;
                await repository.CreateAsync(post);
                return ApiResponse.Created("Create Answer Succes");

            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}

