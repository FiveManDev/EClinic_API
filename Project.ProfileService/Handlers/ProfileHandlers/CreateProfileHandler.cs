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

namespace Project.ProfileService.Handlers.ProfileHandlers
{
    public class CreateProfileDtosHandler : IRequestHandler<CreateProfileCommands, ObjectResult>
    {
        private readonly IProfileRepository profileRepository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly ILogger<CreateUserProfileHandler> logger;

        public CreateProfileDtosHandler(IProfileRepository profileRepository, IAmazonS3Bucket s3Bucket, ILogger<CreateUserProfileHandler> logger)
        {
            this.profileRepository = profileRepository;
            this.s3Bucket = s3Bucket;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(CreateProfileCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var profile = new Profile
                {
                    UserID = Guid.Empty,
                    Address = request.CreateProfileDtos.Address,
                    DateOfBirth = request.CreateProfileDtos.DateOfBirth,
                    FirstName = request.CreateProfileDtos.FirstName,
                    LastName = request.CreateProfileDtos.LastName,
                    Email = request.CreateProfileDtos.Email,
                    Gender = request.CreateProfileDtos.Gender,
                    Phone = request.CreateProfileDtos.Phone
                };
                if (request.CreateProfileDtos.Avatar != null)
                {
                    profile.Avatar = await s3Bucket.UploadFileAsync(request.CreateProfileDtos.Avatar, FileType.Image);
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
