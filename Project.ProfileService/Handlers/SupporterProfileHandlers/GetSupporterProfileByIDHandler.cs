using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.ProfileService.Dtos.DoctorProfile;
using Project.ProfileService.Dtos.SupporterProfile;
using Project.ProfileService.Helpers;
using Project.ProfileService.Queries;
using Project.ProfileService.Repository.ProfileRepository;

namespace Project.ProfileService.Handlers.SupporterProfileHandlers
{
    public class GetSupporterProfileByIDHandler : IRequestHandler<GetSupporterProfileByIDQuery, ObjectResult>
    {
        private readonly ILogger<GetSupporterProfileByIDHandler> logger;
        private readonly IProfileRepository repository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly IMapper mapper;

        public GetSupporterProfileByIDHandler(ILogger<GetSupporterProfileByIDHandler> logger, IProfileRepository repository, IAmazonS3Bucket s3Bucket, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.s3Bucket = s3Bucket;
            this.mapper = mapper;
        }

        public async Task<ObjectResult> Handle(GetSupporterProfileByIDQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var supporterProfiles = await repository.GetSupporterProfileAsync(request.UserID);
                if (supporterProfiles == null)
                {
                    return ApiResponse.NotFound("Profile Not Found.");
                }
                var supporteProfileDtos = mapper.Map<SupporterProfileDtos>(supporterProfiles);
                //supporteProfileDtos.Avatar = await s3Bucket.GetUrl(supporteProfileDtos.Avatar);
                return ApiResponse.OK<SupporterProfileDtos>(supporteProfileDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
