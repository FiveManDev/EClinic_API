using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Data;
using Project.ForumService.Dtos.AnswersDtos;
using Project.ForumService.Dtos.Model;
using Project.ForumService.Queries;

namespace Project.ForumService.Handlers.AnswersHandlers
{
    public class GetAnswerHandler : IRequestHandler<GetAnswerQuery, ObjectResult>
    {
        private readonly IMongoDBRepository<Answer> repository;
        private readonly IMongoDBRepository<Hashtag> hashTagRepository;
        private readonly IMapper mapper;
        private readonly IAmazonS3Bucket bucket;
        private readonly ILogger<GetAnswerHandler> logger;

        public GetAnswerHandler(IMongoDBRepository<Answer> repository, IMongoDBRepository<Hashtag> hashTagRepository, IMapper mapper, IAmazonS3Bucket bucket, ILogger<GetAnswerHandler> logger)
        {
            this.repository = repository;
            this.hashTagRepository = hashTagRepository;
            this.mapper = mapper;
            this.bucket = bucket;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(GetAnswerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Answer answer = await repository.GetAsync(a => a.PostID == request.PostID);
                if (answer == null)
                {
                    return ApiResponse.NotFound("Answer Not Found.");
                }
                AnswerDtos answerDtos = mapper.Map<AnswerDtos>(answer);
                var userID = Guid.Parse(request.UserID);
                if (answer.LikeUserIds.Count > 0)
                {
                    answerDtos.IsLike = answer.LikeUserIds.Contains(userID);
                }
                if (string.IsNullOrEmpty(answerDtos.Author.Avatar))
                {
                    answerDtos.Author.Avatar = await bucket.GetFileAsync(ConstantsData.DefaultAvatarKey);
                }
                else
                {
                    answerDtos.Author.Avatar = await bucket.GetFileAsync(answerDtos.Author.Avatar);
                }
                return ApiResponse.OK(answerDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
