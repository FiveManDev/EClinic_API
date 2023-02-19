using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Enum;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.ProfileService.Commands;
using Project.ProfileService.Repository.ProfileRepository;

namespace Project.ProfileService.Handlers.ProfileHandlers
{
    public class UpdateProfileHandler : IRequestHandler<UpdateProfileCommands, ObjectResult>
    {
        private readonly IProfileRepository profileRepository;
        private readonly ILogger<UpdateProfileHandler> logger;
        private readonly IAmazonS3Bucket s3Bucket;

        public UpdateProfileHandler(IProfileRepository profileRepository, ILogger<UpdateProfileHandler> logger, IAmazonS3Bucket s3Bucket)
        {
            this.profileRepository = profileRepository;
            this.logger = logger;
            this.s3Bucket = s3Bucket;
        }

        public async Task<ObjectResult> Handle(UpdateProfileCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var profile = await profileRepository.GetAsync(request.UpdateProfileDtos.ProfileID);
                if (profile == null)
                {
                    return ApiResponse.NotFound("Profile Not Found.");
                }
                var profileDtos = request.UpdateProfileDtos;
                profile.FirstName = profileDtos.FirstName;
                profile.LastName = profileDtos.LastName;
                profile.Email = profileDtos.Email;
                profile.DateOfBirth = profileDtos.DateOfBirth;
                profile.Gender = profileDtos.Gender;
                profile.Address = profileDtos.Address;
                profile.Phone = profile.Phone;
                if (profileDtos.Avatar != null)
                {
                    profile.Avatar = await s3Bucket.UploadFileAsync(profileDtos.Avatar, FileType.Image);
                }
                var updateProfileResult = await profileRepository.UpdateAsync(profile);
                if (!updateProfileResult)
                {
                    throw new Exception("Update Profile Error");
                }
                return ApiResponse.OK("Update Profile Success");
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
