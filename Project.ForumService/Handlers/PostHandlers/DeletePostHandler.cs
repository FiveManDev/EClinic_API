﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Logger;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;

namespace Project.ForumService.Handlers.PostHandlers
{
    public class DeleteCommentHandler : IRequestHandler<DeletePostCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Post> repository;
        private readonly IMongoDBRepository<Answer> answerRepository;
        private readonly IMongoDBRepository<Comment> commentRepository;
        private readonly ILogger<DeleteCommentHandler> logger;
        public DeleteCommentHandler(IMongoDBRepository<Post> repository, IMongoDBRepository<Answer> answerRepository, IMongoDBRepository<Comment> commentRepository, ILogger<DeleteCommentHandler> logger)
        {
            this.repository = repository;
            this.answerRepository = answerRepository;
            this.commentRepository = commentRepository;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(DeletePostCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await repository.GetAsync(request.PostID);
                if (result == null)
                {
                    return ApiResponse.BadRequest("Post Not Found");
                }
                var answer = await answerRepository.GetAsync(a => a.PostID == result.Id);
                var comments = await commentRepository.GetAllAsync(c => c.PostId == result.Id);
                await repository.RemoveAsync(request.PostID);
                if (answer != null)
                {
                    await answerRepository.RemoveAsync(answer.Id);
                }
                if (comments != null)
                {
                    List<Guid> ids = new List<Guid>();
                    foreach (Comment comment in comments)
                    {
                        ids.Add(comment.Id);
                    }
                    if (ids.Count > 0)
                    {
                        await commentRepository.RemoveManyAsync(ids);
                    }
                }
                return ApiResponse.OK("Delete Post Success.");
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
