using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;

namespace Project.ForumService.Handlers.CommentHandlers
{
    public class CreateReplyCommentHandler : IRequestHandler<CreateReplyCommentCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Comment> repository;
        private readonly IMapper mapper;

        public CreateReplyCommentHandler(IMongoDBRepository<Comment> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ObjectResult> Handle(CreateReplyCommentCommands request, CancellationToken cancellationToken)
        {
            try
            {
                Comment comment = await repository.GetAsync(request.CreateReplyCommentDtos.ParentCommentID);
                if (comment == null)
                {
                    return ApiResponse.NotFound("Parent Comment Not Found");
                }
                ReplyComment replyComment = mapper.Map<ReplyComment>(request.CreateReplyCommentDtos);
                replyComment.CreatedAt = DateTime.Now;
                replyComment.UpdatedAt = DateTime.Now;
                comment.ReplyComments.Add(replyComment);
                await repository.UpdateAsync(comment);
                return ApiResponse.Created("Create Reply Comment Succes");
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}

