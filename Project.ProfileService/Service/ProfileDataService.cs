using Grpc.Core;
using Project.ProfileService.Protos;

namespace Project.ProfileService.Service
{
    public class ProfileDataService : Protos.ProfileService.ProfileServiceBase
    {
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
        
    }
}
