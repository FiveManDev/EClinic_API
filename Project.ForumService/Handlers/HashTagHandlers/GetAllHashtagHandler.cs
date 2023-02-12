using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Data;
using Project.ForumService.Queries;

namespace Project.ForumService.Handlers.HashTagHandlers
{
    public class GetAllHashTagHandler : IRequestHandler<GetAllHashtagQuery, ObjectResult>
    {
        private readonly IMongoDBRepository<Hashtag> repository;
        private readonly ILogger<GetAllHashTagHandler> logger;

        public GetAllHashTagHandler(IMongoDBRepository<Hashtag> repository, ILogger<GetAllHashTagHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(GetAllHashtagQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var hashtags = await repository.GetAllAsync();
                return ApiResponse.OK<List<Hashtag>>(hashtags);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
