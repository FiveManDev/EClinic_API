using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;

namespace Project.ForumService.Handlers.CommentHandlers
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Comment> repository;
        private readonly IMapper mapper;

        public CreateCommentHandler(IMongoDBRepository<Comment> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ObjectResult> Handle(CreateCommentCommands request, CancellationToken cancellationToken)
        {
            try
            {
                Comment comment = mapper.Map<Comment>(request.CreateCommentDtos);
                comment.CreatedAt = DateTime.Now;
                comment.UpdatedAt = DateTime.Now;
                await repository.CreateAsync(comment);
                return ApiResponse.Created("Create Comment Succes");

            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}

