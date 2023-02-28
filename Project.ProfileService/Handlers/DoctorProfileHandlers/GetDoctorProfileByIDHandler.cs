using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.ProfileService.Dtos.DoctorProfile;
using Project.ProfileService.Helpers;
using Project.ProfileService.Queries;
using Project.ProfileService.Repository.ProfileRepository;

namespace Project.ProfileService.Handlers.DoctorProfileHandlers
{
    public class GetDoctorProfileByIDHandler : IRequestHandler<GetDoctorProfileByIDQuery, ObjectResult>
    {
        private readonly ILogger<GetDoctorProfileByIDHandler> logger;
        private readonly IProfileRepository repository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly IMapper mapper;

        public GetDoctorProfileByIDHandler(ILogger<GetDoctorProfileByIDHandler> logger, IProfileRepository repository, IAmazonS3Bucket s3Bucket, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.s3Bucket = s3Bucket;
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
                doctorProfileDtos.Avatar = await s3Bucket.GetUrl(doctorProfileDtos.Avatar);
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
