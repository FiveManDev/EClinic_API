using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.ProfileService.Data.Configurations;
using Project.ProfileService.Dtos.Profile;
using Project.ProfileService.Helpers;
using Project.ProfileService.Queries;
using Project.ProfileService.Repository.ProfileRepository;
using Profile = Project.ProfileService.Data.Profile;

namespace Project.ProfileService.Handlers.ProfileHandlers
{
    public class GetSimpleProfileHandler : IRequestHandler<GetSimpleProfileQuery, ObjectResult>
    {
        private readonly IProfileRepository profileRepository;
        private readonly IMapper mapper;
        private readonly ILogger<GetSimpleProfileHandler> logger;
        private readonly IAmazonS3Bucket s3Bucket;

        public GetSimpleProfileHandler(IProfileRepository profileRepository, IMapper mapper, ILogger<GetSimpleProfileHandler> logger, IAmazonS3Bucket s3Bucket)
        {
            this.profileRepository = profileRepository;
            this.mapper = mapper;
            this.logger = logger;
            this.s3Bucket = s3Bucket;
        }

        public async Task<ObjectResult> Handle(GetSimpleProfileQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var profiles = await profileRepository.GetProfilesAsync(request.UserID);
                var key = "";
                var profile = new Profile();
                if (profiles == null)
                {
                    return ApiResponse.NotFound("Profile Not Found.");
                }
                if (profiles.Count == 1)
                {
                    profile = profiles[0];
                    key = profile.Avatar;
                    profile.Avatar = await s3Bucket.GetUrl(profile.Avatar);
                }
                else
                {

                    profile = profiles.SingleOrDefault(x => x.HealthProfile.RelationshipID == ConstantsData.MyRelationshipID);
                    key = profile.Avatar;
                    profile.Avatar = await s3Bucket.GetUrl(profile.Avatar);
                }
                var sampleProfile = mapper.Map<SimpleProfileDtos>(profile);
                sampleProfile.AvatarKey = key;
                return ApiResponse.OK<SimpleProfileDtos>(sampleProfile);

            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
