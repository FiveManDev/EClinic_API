using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;
using Project.ForumService.Dtos.CommentsDtos;
using Project.ForumService.Dtos.PostsDtos;
using Project.ForumService.Queries;
using System.Xml.Linq;

namespace Project.ForumService.Handlers.CommentHandlers
{
    public class UpdateReplyCommentHandler : IRequestHandler<UpdateReplyCommentCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Comment> repository;

        public UpdateReplyCommentHandler(IMongoDBRepository<Comment> repository)
        {
            this.repository = repository;
        }

        public async Task<ObjectResult> Handle(UpdateReplyCommentCommands request, CancellationToken cancellationToken)
        {
            try
            {
                Comment comment = await repository.GetAsync(request.UpdateReplyCommentDtos.ParentCommentID);
                if (comment == null)
                {
                    return ApiResponse.NotFound("Parent Comment not found");
                }
                foreach (ReplyComment replyComment in comment.ReplyComments)
                {
                    if (replyComment.Id == request.UpdateReplyCommentDtos.CommentID)
                    {
                        replyComment.Content = request.UpdateReplyCommentDtos.Content;
                        replyComment.UpdatedAt = DateTime.Now;
                    }
                }
                await repository.UpdateAsync(comment);
                return ApiResponse.OK("Update Comment Success.");
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}
