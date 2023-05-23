using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Logger;
using Project.ProfileService.Dtos.EmployeeProfile;
using Project.ProfileService.Queries;
using Project.ProfileService.Repository.ProfileRepository;

namespace Project.ProfileService.Handlers.EmployeeProfileHandlers
{
    public class GetEmployeeProfileByIDHandler : IRequestHandler<GetEmployeeProfileByIDQuery, ObjectResult>
    {
        private readonly ILogger<GetEmployeeProfileByIDHandler> logger;
        private readonly IProfileRepository repository;
        private readonly IMapper mapper;

        public GetEmployeeProfileByIDHandler(ILogger<GetEmployeeProfileByIDHandler> logger, IProfileRepository repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ObjectResult> Handle(GetEmployeeProfileByIDQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var supporterProfiles = await repository.GetEmployeeProfileAsync(request.UserID);
                if (supporterProfiles == null)
                {
                    return ApiResponse.NotFound("Profile Not Found.");
                }
                var supporteProfileDtos = mapper.Map<EmployeeProfileDtos>(supporterProfiles);
                return ApiResponse.OK<EmployeeProfileDtos>(supporteProfileDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
