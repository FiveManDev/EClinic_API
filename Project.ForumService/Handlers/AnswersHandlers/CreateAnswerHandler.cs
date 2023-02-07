using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
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

        public CreateAnswerHandler(IMongoDBRepository<Answer> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
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
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}

