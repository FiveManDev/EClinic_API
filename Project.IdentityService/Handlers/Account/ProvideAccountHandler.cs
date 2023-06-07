using Grpc.Net.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Enum;
using Project.Common.Functionality;
using Project.Common.Response;
using Project.Common.Security;
using Project.Core.Logger;
using Project.IdentityService.Commands;
using Project.IdentityService.Dtos;
using Project.IdentityService.Protos;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Account
{
    public class ProvideAccountHandler : IRequestHandler<ProvideAccountCommand, ObjectResult>
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<ProvideAccountHandler> logger;
        private readonly ProfileService.ProfileServiceClient client;
        public ProvideAccountHandler(IUserRepository userRepository, ILogger<ProvideAccountHandler> logger, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.logger = logger;
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            GrpcChannel channel = GrpcChannel.ForAddress(configuration.GetValue<string>("GrpcSettings:ProfileServiceUrl"), new GrpcChannelOptions { HttpHandler = httpHandler });
            client = new ProfileService.ProfileServiceClient(channel);
        }

        public async Task<ObjectResult> Handle(ProvideAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var checkEmail = await client.EmailIsExistAsync(new CheckEmailRequest { Email = request.ProviderAccountReqDtos.Email });
                if (!checkEmail.IsExist)
                {
                    return ApiResponse.NotFound("Profile not found");
                }
                var user = await userRepository.GetAsync(Guid.Parse(checkEmail.UserID));
                if (!string.Equals(user.RoleID, request.RoleID))
                {
                    return ApiResponse.BadRequest("Role not true.");
                }
                var passwordGeneration = RandomText.RandomByNumberOfCharacters(15, RandomType.String);
                var pass = Cryptography.EncryptPassword(passwordGeneration);
                user.PasswordSalt = pass.Salt;
                user.PasswordHash = pass.Hash;
                user.Enabled = true;
                var result = await userRepository.UpdateAsync(user);
                if (!result)
                {
                    throw new Exception("Provider Account Erorr.");
                }
                var account = new ProviderAccountDtos { UserName = user.UserName, Password = passwordGeneration };
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
