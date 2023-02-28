using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.ProfileService.Dtos.Profile;
using Project.ProfileService.Helpers;
using Project.ProfileService.Queries;
using Project.ProfileService.Repository.ProfileRepository;

namespace Project.ProfileService.Handlers.ProfileHandlers
{
    public class GetProfileByIDHandler : IRequestHandler<GetProfileByIDQuery, ObjectResult>
    {
        private readonly ILogger<GetProfileByIDHandler> logger;
        private readonly IProfileRepository repository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly IMapper mapper;

        public GetProfileByIDHandler(ILogger<GetProfileByIDHandler> logger, IProfileRepository repository, IAmazonS3Bucket s3Bucket, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.s3Bucket = s3Bucket;
            this.mapper = mapper;
        }

        public async Task<ObjectResult> Handle(GetProfileByIDQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var profiles = await repository.GetProfileAsync(request.UserID);
                if (profiles == null)
                {
                    return ApiResponse.NotFound("Profile Not Found.");
                }
                var profileDtos = mapper.Map<ProfileDtos>(profiles);
                profileDtos.Avatar = await s3Bucket.GetUrl(profileDtos.Avatar);
                return ApiResponse.OK<ProfileDtos>(profileDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
