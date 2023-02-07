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
    public class GetAllCommentHandler : IRequestHandler<GetAllPostQuery, ObjectResult>
    {
        private readonly IMongoDBRepository<Post> repository;
        private readonly IMapper mapper;

        public GetAllCommentHandler(IMongoDBRepository<Post> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
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
                return ApiResponse.OK<List<PostDtos>>(postDtos);
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}
