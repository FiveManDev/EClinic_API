using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Enum;
using Project.Common.Response;
using Project.Core.AWS;
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
        private readonly IAmazonS3Bucket bucket;
        public CreateCommentHandler(IMongoDBRepository<Post> repository, IMapper mapper, ILogger<CreateCommentHandler> logger, IAmazonS3Bucket bucket)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
            this.bucket = bucket;
        }

        public async Task<ObjectResult> Handle(CreatePostCommands request, CancellationToken cancellationToken)
        {
            try
            {
                Post post = mapper.Map<Post>(request.createPostDtos);
                post.CreatedAt = DateTime.Now;
                post.UpdatedAt = DateTime.Now;
                post.IsActive = false;
                post.Image = await bucket.UploadManyFileAsync(request.createPostDtos.Images, FileType.Image);
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

