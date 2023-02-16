using Grpc.Core;
using MediatR;
using Project.ProfileService.Protos;
using Project.ProfileService.Repository.ProfileRepository;

namespace Project.ProfileService.Service
{
    public class ProfileDataService : Protos.ProfileService.ProfileServiceBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<ProfileDataService> logger;
        private readonly IProfileRepository profileRepository;
        public ProfileDataService(IMediator mediator, ILogger<ProfileDataService> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        public override Task<ProfileResponse> CreateProfile(ProfileCreateRequest request, ServerCallContext context)
        {
            Console.WriteLine(request.LastName);
            var result = Task.FromResult(new ProfileResponse
            {
                IsSuccess = true
            });
            return result;
        }
        public override Task<ProfileResponse> CheckEmail(CheckEmailRequest request, ServerCallContext context)
        {
            Console.WriteLine(request.Email);
            var result = Task.FromResult(new ProfileResponse
            {
                IsSuccess = true,
                UserID = Guid.NewGuid().ToString()
            }); 
            return result;
        }
        public override Task<CheckProfileResponse> CheckProfile(CheckProfileRequest request, ServerCallContext context)
        {
            Console.WriteLine(request.ProfileID);
            var result = Task.FromResult(new CheckProfileResponse
            {
                IsSuccess = true,
                Email = "Test@gmail.com"
            });
            return result;
        }
        public override Task<UpdateProfileResponse> UpdateProfile(ProfileUpdateRequest request, ServerCallContext context)
        {
            Console.WriteLine(request.UserID);
            Console.WriteLine(request.ProfileID);
            var result = Task.FromResult(new UpdateProfileResponse
            {
                IsSuccess = true,
            });
            return result;
        }
    }
}
