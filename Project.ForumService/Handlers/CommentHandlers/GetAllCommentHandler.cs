using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Data;
using Project.ForumService.Dtos.CommentsDtos;
using Project.ForumService.Queries;

namespace Project.ForumService.Handlers.CommentHandlers
{
    public class GetAllCommentHandler : IRequestHandler<GetAllCommentQuery, ObjectResult>
    {
        private readonly IMongoDBRepository<Comment> repository;
        private readonly IMapper mapper;
        private readonly ILogger<GetAllCommentHandler> logger;
        private readonly IAmazonS3Bucket bucket;

        public GetAllCommentHandler(IMongoDBRepository<Comment> repository, IMapper mapper, ILogger<GetAllCommentHandler> logger, IAmazonS3Bucket bucket)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
            this.bucket = bucket;
        }

        public async Task<ObjectResult> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Comment> comments = await repository.GetAllAsync(c => c.PostId == request.PostID);
                if (comments == null)
                {
                    return ApiResponse.NotFound("Comment Not Found.");
                }
                List<CommentDtos> commentDtos = mapper.Map<List<CommentDtos>>(comments);


                foreach (CommentDtos comment in commentDtos)
                {

                    comment.Author.Avatar = await bucket.GetFileAsync(comment.Author.Avatar);

                    comment.IsLike = false;
                    if (!string.IsNullOrEmpty(request.UserID))
                    {
                        Guid userID = Guid.Parse(request.UserID);
                        comment.IsLike = comment.LikeUserIds.Contains(userID);
                        
                    }
                    foreach (ReplyCommentDtos replyCommentDtos in comment.ReplyCommentDtos)
                    {
                        if (!string.IsNullOrEmpty(request.UserID))
                        {
                            Guid userID = Guid.Parse(request.UserID);
                            replyCommentDtos.IsLike = replyCommentDtos.LikeUserIds.Contains(userID);
                        }
                        replyCommentDtos.Author.Avatar = await bucket.GetFileAsync(replyCommentDtos.Author.Avatar);

                    }

                }
                return ApiResponse.OK<List<CommentDtos>>(commentDtos);

            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
