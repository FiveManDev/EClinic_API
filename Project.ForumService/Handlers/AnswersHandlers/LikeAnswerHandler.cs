using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;
using Project.ForumService.Queries;

namespace Project.ForumService.Handlers.AnswersHandlers
{
    public class LikeAnswerHandler : IRequestHandler<LikeAnswerCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Answer> repository;

        public LikeAnswerHandler(IMongoDBRepository<Answer> repository)
        {
            this.repository = repository;
        }

        public async Task<ObjectResult> Handle(LikeAnswerCommands request, CancellationToken cancellationToken)
        {
            try
            {
                Answer answer = await repository.GetAsync(request.AnswerID);
                if (answer == null)
                {
                    return ApiResponse.NotFound("Answer Not Found.");
                }
                var userID = Guid.Parse(request.UserID);
                var result = answer.LikeUserIds.Contains(userID);
                if (result)
                {
                    answer.LikeUserIds.Remove(userID);
                }
                else
                {
                    answer.LikeUserIds.Add(userID);
                }


                await repository.UpdateAsync(answer);
                return ApiResponse.OK("Update Like Answer Success");

            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}
