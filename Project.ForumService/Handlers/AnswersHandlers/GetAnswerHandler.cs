using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Project.Common.Response;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;
using Project.ForumService.Dtos.AnswersDtos;
using Project.ForumService.Dtos.PostsDtos;
using Project.ForumService.Queries;

namespace Project.ForumService.Handlers.AnswersHandlers
{
    public class GetAnswerHandler : IRequestHandler<GetAnswerQuery, ObjectResult>
    {
        private readonly IMongoDBRepository<Answer> repository;
        private readonly IMapper mapper;

        public GetAnswerHandler(IMongoDBRepository<Answer> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ObjectResult> Handle(GetAnswerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Answer answer = await repository.GetAsync(a=>a.PostID == request.PostID);
                if (answer == null)
                {
                    return ApiResponse.NotFound("Answer Not Found.");
                }
                AnswerDtos answerDtos = mapper.Map<AnswerDtos>(answer);
                var userID = Guid.Parse(request.UserID);
                if(answer.LikeUserIds !=null)
                {
                    answerDtos.IsLike = answer.LikeUserIds.Contains(userID);
                }
                
                return ApiResponse.OK(answerDtos);
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}
