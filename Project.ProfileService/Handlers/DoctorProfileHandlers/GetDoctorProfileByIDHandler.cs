using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Logger;
using Project.ProfileService.Dtos.DoctorProfile;
using Project.ProfileService.Queries;
using Project.ProfileService.Repository.ProfileRepository;

namespace Project.ProfileService.Handlers.DoctorProfileHandlers
{
    public class GetDoctorProfileByIDHandler : IRequestHandler<GetDoctorProfileByIDQuery, ObjectResult>
    {
        private readonly ILogger<GetDoctorProfileByIDHandler> logger;
        private readonly IProfileRepository repository;
        private readonly IMapper mapper;

        public GetDoctorProfileByIDHandler(ILogger<GetDoctorProfileByIDHandler> logger, IProfileRepository repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ObjectResult> Handle(GetDoctorProfileByIDQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var doctorProfiles = await repository.GetDoctorProfileAsync(request.UserID);
                if (doctorProfiles == null)
                {
                    return ApiResponse.NotFound("Profile Not Found.");
                }
                var doctorProfileDtos = mapper.Map<DoctorProfileDtos>(doctorProfiles);
                return ApiResponse.OK<DoctorProfileDtos>(doctorProfileDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
