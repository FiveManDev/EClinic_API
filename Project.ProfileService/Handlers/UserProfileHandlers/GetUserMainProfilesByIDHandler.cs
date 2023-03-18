using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.ProfileService.Data.Configurations;
using Project.ProfileService.Dtos.UserProfile;
using Project.ProfileService.Helpers;
using Project.ProfileService.Queries;
using Project.ProfileService.Repository.ProfileRepository;
using Project.ProfileService.Repository.RelationshipRepository;
using System.Reflection.Metadata;

namespace Project.ProfileService.Handlers.UserProfileHandlers
{
    public class GetUserMainProfilesByIDHandler : IRequestHandler<GetUserMainProfilesByIDQuery, ObjectResult>
    {
        private readonly ILogger<GetUserMainProfilesByIDHandler> logger;
        private readonly IProfileRepository repository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly IMapper mapper;
        private readonly IRelationshipRepository relationshipRepository;

        public GetUserMainProfilesByIDHandler(ILogger<GetUserMainProfilesByIDHandler> logger, IProfileRepository repository, IAmazonS3Bucket s3Bucket, IMapper mapper, IRelationshipRepository relationshipRepository)
        {
            this.logger = logger;
            this.repository = repository;
            this.s3Bucket = s3Bucket;
            this.mapper = mapper;
            this.relationshipRepository = relationshipRepository;
        }

        public async Task<ObjectResult> Handle(GetUserMainProfilesByIDQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var UserID = Guid.Parse(request.UserID);
                var userProfiles = await repository.GetProfilesAsync(UserID);
                if (userProfiles == null)
                {
                    return ApiResponse.NotFound("Profile Not Found.");
                }
                var mainProfile = userProfiles.SingleOrDefault(x => x.HealthProfile.RelationshipID == ConstantsData.MyRelationshipID);
                var userProfileDtos = mapper.Map<UserProfileDtos>(mainProfile);
                userProfileDtos.Avatar = await s3Bucket.GetUrl(userProfileDtos.Avatar);
                var relationship = await relationshipRepository.GetAsync(userProfileDtos.RelationshipID);
                userProfileDtos.RelationshipName = relationship.RelationshipName;

                return ApiResponse.OK<UserProfileDtos>(userProfileDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
