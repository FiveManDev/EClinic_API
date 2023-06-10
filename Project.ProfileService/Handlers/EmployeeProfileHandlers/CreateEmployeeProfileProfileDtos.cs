using Grpc.Net.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Constants;
using Project.Common.Enum;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.ProfileService.Commands;
using Project.ProfileService.Data;
using Project.ProfileService.Data.Configurations;
using Project.ProfileService.Handlers.UserProfileHandlers;
using Project.ProfileService.Protos;
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
        private readonly UserService.UserServiceClient client;

        public CreateEmployeeProfileProfileDtos(IConfiguration configuration,IProfileRepository profileRepository, IEmployeeProfilesRepository employeeProfilesRepository, IAmazonS3Bucket s3Bucket, ILogger<CreateUserProfileHandler> logger)
        {
            this.profileRepository = profileRepository;
            this.employeeProfilesRepository = employeeProfilesRepository;
            this.s3Bucket = s3Bucket;
            this.logger = logger;
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            GrpcChannel channel = GrpcChannel.ForAddress(configuration.GetValue<string>("GrpcSettings:IdentityServiceUrl"), new GrpcChannelOptions { HttpHandler = httpHandler });
            client = new UserService.UserServiceClient(channel);
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
                    profile.Avatar = await s3Bucket.GetFileAsync(ConstantsData.DefaultAvatarKey);
                }
                var userRes = await client.CreateUserAsync(new CreateUserRequest { Email = profile.Email, Role = request.Role, Enabled = request.CreateEmployeeProfileDtos.EnabledAccount });
                if (!userRes.IsSuccess)
                {
                    return ApiResponse.InternalServerError();
                }
                profile.UserID = Guid.Parse(userRes.UserID);
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
                return ApiResponse.Created<Guid>(supporter.ProfileID);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
