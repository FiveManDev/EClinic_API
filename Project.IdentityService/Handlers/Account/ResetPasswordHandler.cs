using Grpc.Net.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Common.Security;
using Project.Core.Logger;
using Project.IdentityService.Commands;
using Project.IdentityService.Dtos;
using Project.IdentityService.Protos;
using Project.IdentityService.Repository.UserRepository;
using System.Reflection;

namespace Project.IdentityService.Handlers.Account
{
    public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, ObjectResult>
    {
        private readonly IUserRepository userRepository;
        private readonly GrpcChannel channel;
        private readonly ProfileService.ProfileServiceClient client;
        private readonly IConfiguration configuration;
        private readonly ILogger<ResetPasswordHandler> logger;

        public ResetPasswordHandler(IUserRepository userRepository, IConfiguration configuration, ILogger<ResetPasswordHandler> logger)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
            channel = GrpcChannel.ForAddress(configuration.GetValue<string>("GrpcSettings:ProfileServiceUrl"));
            client = new ProfileService.ProfileServiceClient(channel);
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resultCheckMail = await client.CheckEmailAsync(new CheckEmailRequest { Email = request.ResetPasswordDTO.Email });
                if (!resultCheckMail.IsSuccess)
                {
                    return ApiResponse.NotFound("Account not found");
                }
                if (!string.Equals(request.ResetPasswordDTO.NewPassword, request.ResetPasswordDTO.ConfirmPassword))
                {
                    return ApiResponse.BadRequest("Password and Confirm Password are not the same");
                }
                var userID = Guid.Parse(resultCheckMail.UserID);
                var user = await userRepository.GetAsync(userID);
                var pass = Cryptography.EncryptPassword(request.ResetPasswordDTO.NewPassword);
                user.PasswordSalt = pass.Salt;
                user.PasswordHash = pass.Hash;
                var result = await userRepository.UpdateAsync(user);
                if (!result)
                {
                    return ApiResponse.InternalServerError();
                }
                return ApiResponse.OK("Reset password success");
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
