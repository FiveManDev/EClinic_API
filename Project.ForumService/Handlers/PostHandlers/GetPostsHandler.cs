using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Data;
using Project.ForumService.Dtos.Model;
using Project.ForumService.Dtos.PostsDtos;
using Project.ForumService.Queries;

namespace Project.ForumService.Handlers.PostHandlers
{
    public class GetPostsHandler : IRequestHandler<GetPostsQuery, ObjectResult>
    {
        private readonly IMongoDBRepository<Post> postRepository;
        private readonly IMongoDBRepository<Answer> answerRepository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly IMapper mapper;
        private readonly ILogger<GetPostsHandler> logger;

        public GetPostsHandler(IMongoDBRepository<Post> postRepository, IMongoDBRepository<Answer> answerRepository, IAmazonS3Bucket s3Bucket, IMapper mapper, ILogger<GetPostsHandler> logger)
        {
            this.postRepository = postRepository;
            this.answerRepository = answerRepository;
            this.s3Bucket = s3Bucket;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var posts = await postRepository.GetAllAsync(x => x.Title.Contains(request.SearchText) || x.Content.Contains(request.SearchText));
                if (posts == null)
                {
                    return ApiResponse.NotFound("Post Not Found.");
                }
                posts.Skip((request.PaginationRequestHeader.PageNumber - 1) * request.PaginationRequestHeader.PageSize).Take(request.PaginationRequestHeader.PageSize);
                List<PostDtos> postDtos = mapper.Map<List<PostDtos>>(posts);
                foreach (PostDtos post in postDtos)
                {
                    if (post.Image.Count > 0)
                    {
                        var images = await s3Bucket.GetManyFileAsync(post.Image);
                        post.Image = images;
                    }
                    if (string.IsNullOrEmpty(post.Author.Avatar))
                    {
                        post.Author.Avatar = await s3Bucket.GetFileAsync(ConstantsData.DefaultAvatarKey);
                    }
                    else
                    {
                        post.Author.Avatar = await s3Bucket.GetFileAsync(post.Author.Avatar);
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
