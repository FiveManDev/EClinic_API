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
    public class GetCommentHandler : IRequestHandler<GetPostQuery, ObjectResult>
    {
        private readonly IMongoDBRepository<Post> repository;
        private readonly IMapper mapper;
        private readonly ILogger<GetCommentHandler> logger;
        private readonly IAmazonS3Bucket bucket;

        public GetCommentHandler(IMongoDBRepository<Post> repository, IMapper mapper, ILogger<GetCommentHandler> logger, IAmazonS3Bucket bucket)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
            this.bucket = bucket;
        }

        public async Task<ObjectResult> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Post post = await repository.GetAsync(request.PostID);
                if (post == null)
                {
                    return ApiResponse.NotFound("Post Not Found.");
                }
                PostDtos postDtos = mapper.Map<PostDtos>(post);
                var userID = Guid.Parse(request.UserID);
                if(post.LikeUserIds.Count>0)
                {
                    postDtos.IsLike = post.LikeUserIds.Contains(userID);
                }
                if (post.Image.Count > 0)
                {
                    var images = await bucket.GetManyFileAsync(post.Image);
                    post.Image = images;
                }
                return ApiResponse.OK(postDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
