using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Project.Common.Constants;
using Project.Common.Response;
using Project.Common.Security;
using Project.Core.Logger;
using Project.Core.RabbitMQ;
using Project.IdentityService.Commands;
using Project.IdentityService.Data;
using Project.IdentityService.Protos;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Account
{
    public class SignUpHandler : IRequestHandler<SignUpCommand, ObjectResult>
    {
        private readonly IUserRepository userRepository;
        private readonly GrpcChannel channel;
        private readonly ProfileService.ProfileServiceClient client;
        private readonly IConfiguration configuration;
        private readonly ILogger<SignUpHandler> logger;

        public SignUpHandler(IUserRepository userRepository, IConfiguration configuration, ILogger<SignUpHandler> logger)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
            channel = GrpcChannel.ForAddress(configuration.GetValue<string>("GrpcSettings:ProfileServiceUrl"));
            client = new ProfileService.ProfileServiceClient(channel);
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var isUserNameExist = await userRepository.AnyAsync(user => user.UserName == request.SignUpDtos.UserName);
                if (isUserNameExist)
                {
                    return ApiResponse.BadRequest("User Name is exist");
                }
                if (!request.SignUpDtos.Password.Equals(request.SignUpDtos.ConfirmPassword))
                {
                    return ApiResponse.BadRequest("Password and confirm password are not the same");
                }
                var checkEmail = await client.CheckEmailAsync(new CheckEmailRequest { Email = request.SignUpDtos.Email });
                if (!checkEmail.IsSuccess)
                {
                    return ApiResponse.BadRequest("Email is exist");
                }
                var pass = Cryptography.EncryptPassword(request.SignUpDtos.Password);
                var user = new User { UserName = request.SignUpDtos.UserName, PasswordHash = pass.Hash, PasswordSalt = pass.Salt, RoleID = RoleConstants.IDUser, CreatedAt = DateTime.Now };
                var result = await userRepository.CreateEntityAsync(user);
                if (result == null)
                {
                    return ApiResponse.InternalServerError();
                }
                var response = await client.CreateProfileAsync(new ProfileCreateRequest
                {
                    UserID = result.UserID.ToString(),
                    Email = request.SignUpDtos.Email,
                    FirstName = request.SignUpDtos.FirstName,
                    LastName = request.SignUpDtos.LastName,
                    Gender = request.SignUpDtos.Gender,
                    DateOfBirth = request.SignUpDtos.DateOfBirth.ToTimestamp()
                });
                if (!response.IsSuccess)
                {
                    await userRepository.DeleteAsync(user);
                    return ApiResponse.InternalServerError();
                }
                return ApiResponse.Created("Sign Up Success");
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
