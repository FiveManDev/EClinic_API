using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;
using Project.ForumService.Dtos.PostsDtos;
using Project.ForumService.Queries;

namespace Project.ForumService.Handlers.AnswersHandlers
{
    public class UpdateAnswerHandler : IRequestHandler<UpdateAnswerCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Answer> repository;

        public UpdateAnswerHandler(IMongoDBRepository<Answer> repository)
        {
            this.repository = repository;
        }

        public async Task<ObjectResult> Handle(UpdateAnswerCommands request, CancellationToken cancellationToken)
        {
            try
            {
                Answer answer = await repository.GetAsync(request.UpdateAnswerDtos.AnswerID);
                if (answer == null)
                {
                    return ApiResponse.NotFound("Answer not found");
                }
                answer.Content = request.UpdateAnswerDtos.Content;
                answer.Tag = request.UpdateAnswerDtos.Tag;
                answer.UpdatedAt = DateTime.Now;
                // Sử lý lưu image
                await repository.UpdateAsync(answer);
                return ApiResponse.OK("Update Answer Success.");
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}
