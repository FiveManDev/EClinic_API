using AutoMapper;
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
        public override async Task<EmailExistResponse> EmailIsExist(CheckEmailRequest request, ServerCallContext context)
        {
            try
            {
                var result = await profileRepository.GetAsync(x => x.Email == request.Email);
                var res = new EmailExistResponse();
                if (result != null)
                {
                    res.IsExist = true;
                    res.UserID = result.UserID.ToString();
                    return res;
                }
                res.IsExist = false;
                return res;
            }
            catch
            {
                var res = new EmailExistResponse();
                return res;
            }
        }
        public override async Task<CreateProfileResponse> CreateProfile(CreateProfileRequest request, ServerCallContext context)
        {
            try
            {
                var profile = new Data.Profile
                {
                    UserID = Guid.Parse(request.UserID),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth.ToDateTime(),
                    Gender = request.Gender,
                    Email = request.Email
                };
                var result = await profileRepository.CreateEntityAsync(profile);
                var res = new CreateProfileResponse();
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
            catch
            {
                var res = new CreateProfileResponse();
                res.IsSuccess = false;
                return res;
            }
        }

        public override async Task<GetProfileResponse> GetProfile(GetProfileRequest request, ServerCallContext context)
        {
            try
            {
                var profiles = await  profileRepository.GetProfilesAsync(Guid.Parse(request.UserID));
                var res = new GetProfileResponse();
                if (profiles == null)
                {
                    return res;
                }
                if (profiles.Count >1)
                {
                    foreach (var profile in profiles)
                    {
                        if(profile.HealthProfile.RelationshipID == ConstantsData.MyRelationshipID)
                        {
                            res.UserID = profile.UserID.ToString(); ;
                            res.Avatar = profile.Avatar;
                            res.FirstName = profile.FirstName;
                            res.LastName = profile.LastName;  
                            return res;
                        }
                    }
                }
                res.UserID = profiles[0].UserID.ToString(); ;
                res.Avatar = profiles[0].Avatar;
                res.FirstName = profiles[0].FirstName;
                res.LastName = profiles[0].LastName;
                return res;
            }
            catch
            {
                var res = new GetProfileResponse();
                return res;
            }
        }
    }
}
