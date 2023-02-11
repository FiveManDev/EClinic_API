using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Logger;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;

namespace Project.ForumService.Handlers.CommentHandlers
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Comment> repository;
        private readonly IMapper mapper;
        private readonly ILogger<CreateCommentHandler> logger;
        public CreateCommentHandler(IMongoDBRepository<Comment> repository, IMapper mapper, ILogger<CreateCommentHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
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
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}

