using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Project.Common.Response;
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

        public GetCommentHandler(IMongoDBRepository<Post> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
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
                if(post.LikeUserIds!=null)
                {
                    postDtos.IsLike = post.LikeUserIds.Contains(userID);
                }
                return ApiResponse.OK(postDtos);
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}
