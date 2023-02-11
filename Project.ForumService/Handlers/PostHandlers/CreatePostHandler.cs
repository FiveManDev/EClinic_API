using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Logger;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;

namespace Project.ForumService.Handlers.PostHandlers
{
    public class CreateCommentHandler : IRequestHandler<CreatePostCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Post> repository;
        private readonly IMapper mapper;
        private readonly ILogger<CreateCommentHandler> logger;
        public CreateCommentHandler(IMongoDBRepository<Post> repository, IMapper mapper, ILogger<CreateCommentHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
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
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}

