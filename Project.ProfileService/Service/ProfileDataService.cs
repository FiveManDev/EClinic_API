using Grpc.Core;
using Project.ProfileService.Data;
using Project.ProfileService.Data.Configurations;
using Project.ProfileService.Protos;
using Project.ProfileService.Repository.HealthProfileRepository;
using Project.ProfileService.Repository.ProfileRepository;

namespace Project.ProfileService.Service
{
    public class ProfileDataService : Protos.ProfileService.ProfileServiceBase
    {
        private readonly IProfileRepository profileRepository;
        private readonly IHealthProfileRepository healthProfileRepository;

        public ProfileDataService(IProfileRepository profileRepository, IHealthProfileRepository healthProfileRepository)
        {
            this.profileRepository = profileRepository;
            this.healthProfileRepository = healthProfileRepository;
        }

        public override async Task<ProfileResponse> CreateProfile(ProfileCreateRequest request, ServerCallContext context)
        {
            var profile = new Profile
            {
                UserID = Guid.Parse(request.UserID),
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth.ToDateTime(),
                Gender = request.Gender,
                Email = request.Email
            };
            var result = await profileRepository.CreateEntityAsync(profile);
            var res = new ProfileResponse();
            if (result == null)
            {
                res.IsSuccess = false;
                return res;
            }
            var health = new HealthProfile { ProfileID = result.ProfileID, RelationshipID = ConstantsData.MyRelationshipID };
            var healthResult = await healthProfileRepository.CreateAsync(health);
            if (!healthResult)
            {
                await profileRepository.DeleteAsync(profile);
                res.IsSuccess = false;
                return res;
            }
            res.IsSuccess = true;
            return res;
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
