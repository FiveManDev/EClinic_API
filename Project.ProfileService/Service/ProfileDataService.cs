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

        public ProfileDataService(IMediator mediator, ILogger<ProfileDataService> logger, IProfileRepository profileRepository)
        {
            this.mediator = mediator;
            this.logger = logger;
            this.profileRepository = profileRepository;
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
        public override async Task<ProfileResponse> CheckEmail(CheckEmailRequest request, ServerCallContext context)
        {
            var result = await profileRepository.GetAsync(x => x.Email == request.Email);
            var res = new ProfileResponse();
            if (result == null)
            {
                res.IsSuccess = true;
                return res;
            }
            res.IsSuccess = false;
            res.UserID = result.UserID.ToString();
            return res;
        }
        public override async Task<CheckProfileResponse> CheckProfile(CheckProfileRequest request, ServerCallContext context)
        {
            var result = await profileRepository.GetAsync(Guid.Parse(request.ProfileID));
            var res = new CheckProfileResponse();
            if (result == null)
            {
                res.IsSuccess = false;
                return res;
            }
            res.IsSuccess = true;
            res.Email = result.Email;
            return res;
        }
        public override async Task<UpdateProfileResponse> UpdateProfile(ProfileUpdateRequest request, ServerCallContext context)
        {
            var profile = await profileRepository.GetAsync(Guid.Parse(request.ProfileID));
            var res = new UpdateProfileResponse();
            if (profile == null)
            {
                res.IsSuccess = false;
                return res;
            }
            profile.UserID = Guid.Parse(request.UserID);
            var result = await profileRepository.UpdateAsync(profile);
            if (!result)
            {
                res.IsSuccess = false;
                return res;
            }
            res.IsSuccess = true;
            return res;
        }
    }
}
