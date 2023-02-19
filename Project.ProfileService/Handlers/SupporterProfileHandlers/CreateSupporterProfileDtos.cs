using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Enum;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.ProfileService.Commands;
using Project.ProfileService.Data;
using Project.ProfileService.Handlers.UserProfileHandlers;
using Project.ProfileService.Repository.ProfileRepository;
using Project.ProfileService.Repository.SupporterProfileRepository;

namespace Project.ProfileService.Handlers.SupporterProfileHandlers
{
    public class CreateSupporterProfileDtos : IRequestHandler<CreateSupporterProfileCommands, ObjectResult>
    {
        private readonly IProfileRepository profileRepository;
        private readonly ISupporterProfileRepository supporterProfileRepository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly ILogger<CreateUserProfileHandler> logger;

        public CreateSupporterProfileDtos(IProfileRepository profileRepository, ISupporterProfileRepository supporterProfileRepository, IAmazonS3Bucket s3Bucket, ILogger<CreateUserProfileHandler> logger)
        {
            this.profileRepository = profileRepository;
            this.supporterProfileRepository = supporterProfileRepository;
            this.s3Bucket = s3Bucket;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(CreateSupporterProfileCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var profile = new Profile
                {
                    UserID = Guid.Empty,
                    Address = request.CreateSupporterProfileDtos.Address,
                    DateOfBirth = request.CreateSupporterProfileDtos.DateOfBirth,
                    FirstName = request.CreateSupporterProfileDtos.FirstName,
                    LastName = request.CreateSupporterProfileDtos.LastName,
                    Email = request.CreateSupporterProfileDtos.Email,
                    Gender = request.CreateSupporterProfileDtos.Gender,
                    Phone = request.CreateSupporterProfileDtos.Phone
                };
                if (request.CreateSupporterProfileDtos.Avatar != null)
                {
                    profile.Avatar = await s3Bucket.UploadFileAsync(request.CreateSupporterProfileDtos.Avatar, FileType.Image);
                }
                else
                {
                    profile.Avatar = null;
                }
                var result = await profileRepository.CreateEntityAsync(profile);
                if (result == null)
                {
                    throw new Exception("Create Profile Error");
                }
                var supporter = new SupporterProfile
                {
                    ProfileID = result.ProfileID,
                    Description = request.CreateSupporterProfileDtos.Description,
                    WorkStart = request.CreateSupporterProfileDtos.WorkStart,
                };
                var supporterResult = await supporterProfileRepository.CreateAsync(supporter);
                if (!supporterResult)
                {
                    await profileRepository.DeleteAsync(profile);
                }
                return ApiResponse.Created("Create Success");
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
