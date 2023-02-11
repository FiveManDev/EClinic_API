using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;
using Project.ForumService.Dtos.PostsDtos;
using Project.ForumService.Queries;

namespace Project.ForumService.Handlers.PostHandlers
{
    public class GetAllCommentHandler : IRequestHandler<GetAllPostQuery, ObjectResult>
    {
        private readonly IMongoDBRepository<Post> repository;
        private readonly IMapper mapper;
        private readonly ILogger<GetAllCommentHandler> logger;
        private readonly IAmazonS3Bucket bucket;
        public GetAllCommentHandler(IMongoDBRepository<Post> repository, IMapper mapper, ILogger<GetAllCommentHandler> logger, IAmazonS3Bucket bucket)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
            this.bucket = bucket;
        }

        public async Task<ObjectResult> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var posts = await repository.GetAllAsync();
                if (posts == null)
                {
                    return ApiResponse.NotFound("Post Not Found.");
                }
                List<PostDtos> postDtos = mapper.Map<List<PostDtos>>(posts);
                foreach (PostDtos post in postDtos)
                {
                    if (post.Image.Count > 0)
                    {
                        var images = await bucket.GetManyFileAsync(post.Image);
                        post.Image = images;
                    }
                }
                return ApiResponse.OK<List<PostDtos>>(postDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
