using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Logger;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Commands;
using Project.ForumService.Data;
using Project.ForumService.Dtos.PostsDtos;

namespace Project.ForumService.Handlers.PostHandlers
{
    public class CreateAnswerHandler : IRequestHandler<CreateAnswerCommands, ObjectResult>
    {
        private readonly IMongoDBRepository<Answer> repository;
        private readonly IMapper mapper;
        private readonly ILogger<CreateAnswerHandler> logger;

        public CreateAnswerHandler(IMongoDBRepository<Answer> repository, IMapper mapper, ILogger<CreateAnswerHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(CreateAnswerCommands request, CancellationToken cancellationToken)
        {
            try
            {
                Answer answer = mapper.Map<Answer>(request.CreateAnswerDtos);
                answer.CreatedAt = DateTime.Now;
                answer.UpdatedAt = DateTime.Now;
                await repository.CreateAsync(answer);
                return ApiResponse.Created("Create Answer Succes");
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}

