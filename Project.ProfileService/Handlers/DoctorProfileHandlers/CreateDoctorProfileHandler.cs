using Grpc.Net.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Project.Common.Constants;
using Project.Common.Enum;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.ProfileService.Commands;
using Project.ProfileService.Data;
using Project.ProfileService.Handlers.UserProfileHandlers;
using Project.ProfileService.Protos;
using Project.ProfileService.Repository.DoctorProfileRepository;
using Project.ProfileService.Repository.ProfileRepository;
using System.Threading.Channels;

namespace Project.ProfileService.Handlers.DoctorProfileHandlers
{
    public class CreateDoctorProfileHandler : IRequestHandler<CreateDoctorProfileCommands, ObjectResult>
    {
        private readonly IProfileRepository profileRepository;
        private readonly IDoctorProfileRepository doctorProfileRepository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly ILogger<CreateUserProfileHandler> logger;
        private readonly UserService.UserServiceClient client;

        public CreateDoctorProfileHandler(IConfiguration configuration, IProfileRepository profileRepository, IDoctorProfileRepository doctorProfileRepository, IAmazonS3Bucket s3Bucket, ILogger<CreateUserProfileHandler> logger)
        {
            this.profileRepository = profileRepository;
            this.doctorProfileRepository = doctorProfileRepository;
            this.s3Bucket = s3Bucket;
            this.logger = logger;
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            GrpcChannel channel = GrpcChannel.ForAddress(configuration.GetValue<string>("GrpcSettings:IdentityServiceUrl"), new GrpcChannelOptions { HttpHandler = httpHandler });
            client = new UserService.UserServiceClient(channel);
        }

        public async Task<ObjectResult> Handle(CreateDoctorProfileCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var profile = new Profile
                {
                    UserID = Guid.Empty,
                    Address = request.CreateDoctorProfileDtos.Address,
                    DateOfBirth = request.CreateDoctorProfileDtos.DateOfBirth,
                    FirstName = request.CreateDoctorProfileDtos.FirstName,
                    LastName = request.CreateDoctorProfileDtos.LastName,
                    Email = request.CreateDoctorProfileDtos.Email,
                    Gender = request.CreateDoctorProfileDtos.Gender,
                    Phone = request.CreateDoctorProfileDtos.Phone
                };
                if (request.CreateDoctorProfileDtos.Avatar != null)
                {
                    profile.Avatar = await s3Bucket.UploadFileAsync(request.CreateDoctorProfileDtos.Avatar, FileType.Image);
                }
                else
                {
                    profile.Avatar = null;
                }
                var userRes = await client.CreateUserAsync(new CreateUserRequest { Email = profile.Email, Role = RoleConstants.Doctor });
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
                
                var doctor = new DoctorProfile
                {
                    ProfileID = result.ProfileID,
                    Description = request.CreateDoctorProfileDtos.Description,
                    SpecializationID = request.CreateDoctorProfileDtos.SpecializationID,
                    Title = request.CreateDoctorProfileDtos.Title,
                    Quality = 5,
                    WorkStart = request.CreateDoctorProfileDtos.WorkStart
                };
                var doctorResult = await doctorProfileRepository.CreateAsync(doctor);
                if (!doctorResult)
                {
                    await profileRepository.DeleteAsync(profile);
                    throw new Exception("Create Doctor Profile Error.");
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
