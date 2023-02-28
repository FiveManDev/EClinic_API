using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Enum;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.ProfileService.Commands;
using Project.ProfileService.Data;
using Project.ProfileService.Handlers.UserProfileHandlers;
using Project.ProfileService.Repository.EmployeeProfileRepository;
using Project.ProfileService.Repository.ProfileRepository;

namespace Project.ProfileService.Handlers.EmployeeProfileHandlers
{
    public class CreateEmployeeProfileProfileDtos : IRequestHandler<CreateEmployeeProfileCommands, ObjectResult>
    {
        private readonly IProfileRepository profileRepository;
        private readonly IEmployeeProfilesRepository employeeProfilesRepository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly ILogger<CreateUserProfileHandler> logger;

        public CreateEmployeeProfileProfileDtos(IProfileRepository profileRepository, IEmployeeProfilesRepository employeeProfilesRepository, IAmazonS3Bucket s3Bucket, ILogger<CreateUserProfileHandler> logger)
        {
            this.profileRepository = profileRepository;
            this.employeeProfilesRepository = employeeProfilesRepository;
            this.s3Bucket = s3Bucket;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(CreateEmployeeProfileCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var profile = new Profile
                {
                    UserID = Guid.Empty,
                    Address = request.CreateEmployeeProfileDtos.Address,
                    DateOfBirth = request.CreateEmployeeProfileDtos.DateOfBirth,
                    FirstName = request.CreateEmployeeProfileDtos.FirstName,
                    LastName = request.CreateEmployeeProfileDtos.LastName,
                    Email = request.CreateEmployeeProfileDtos.Email,
                    Gender = request.CreateEmployeeProfileDtos.Gender,
                    Phone = request.CreateEmployeeProfileDtos.Phone
                };
                if (request.CreateEmployeeProfileDtos.Avatar != null)
                {
                    profile.Avatar = await s3Bucket.UploadFileAsync(request.CreateEmployeeProfileDtos.Avatar, FileType.Image);
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
                var supporter = new EmployeeProfile
                {
                    ProfileID = result.ProfileID,
                    Description = request.CreateEmployeeProfileDtos.Description,
                    WorkStart = request.CreateEmployeeProfileDtos.WorkStart,
                };
                var supporterResult = await employeeProfilesRepository.CreateAsync(supporter);
                if (!supporterResult)
                {
                    await profileRepository.DeleteAsync(profile);
                    throw new Exception("Create Error.");
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
