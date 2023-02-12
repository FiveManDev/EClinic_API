using Grpc.Net.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Constants;
using Project.Common.Enum;
using Project.Common.Functionality;
using Project.Common.Response;
using Project.Common.Security;
using Project.Core.Logger;
using Project.IdentityService.Commands;
using Project.IdentityService.Data;
using Project.IdentityService.Dtos;
using Project.IdentityService.Protos;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Account
{
    public class ProvideAccountHandler : IRequestHandler<ProvideAccountCommand, ObjectResult>
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<ProvideAccountHandler> logger;
        private readonly GrpcChannel channel;
        private readonly ProfileService.ProfileServiceClient client;
        private readonly IConfiguration configuration;
        public ProvideAccountHandler(IUserRepository userRepository, ILogger<ProvideAccountHandler> logger, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.logger = logger;
            this.configuration = configuration;
            channel = GrpcChannel.ForAddress(configuration.GetValue<string>("GrpcSettings:ProfileServiceUrl"));
            client = new ProfileService.ProfileServiceClient(channel);
        }

        public async Task<ObjectResult> Handle(ProvideAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var checkProfile = await client.CheckProfileAsync(new CheckProfileRequest { ProfileID = request.ProfileID.ToString() });
                if (!checkProfile.IsSuccess)
                {
                    return ApiResponse.BadRequest("Profile not found");
                }
                var userNameGeneration = RoleConstants.Doctor.ToLower() + checkProfile.Email.Substring(0, checkProfile.Email.IndexOf('@'));
                var passwordGeneration = RandomText.RandomByNumberOfCharacters(15, RandomType.String);
                var pass = Cryptography.EncryptPassword(passwordGeneration);
                var user = new User { UserName = userNameGeneration, PasswordHash = pass.Hash, PasswordSalt = pass.Salt, RoleID = request.Role };
                var result = await userRepository.CreateEntityAsync(user);
                if (result == null)
                {
                    throw new Exception("Create User Erorr.");
                }
                var updateProfile = await client.UpdateProfileAsync(new ProfileUpdateRequest { UserID = result.UserID.ToString(), ProfileID = request.ProfileID.ToString() });
                if (!updateProfile.IsSuccess)
                {
                    await userRepository.DeleteAsync(result);
                    throw new Exception("Update Profile in Provider Account Error");
                }
                var account = new ProviderAccountDtos { UserName = userNameGeneration, Password = passwordGeneration };
                return ApiResponse.OK<ProviderAccountDtos>(account);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
