using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Constants;
using Project.Common.Response;
using Project.Common.Security;
using Project.Core.RabbitMQ;
using Project.IdentityService.Commands;
using Project.IdentityService.Data;
using Project.IdentityService.Dtos;
using Project.IdentityService.Events.ProfileEvents;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Account
{
    public class SignUpHandler : IRequestHandler<SignUpCommand, ObjectResult>
    {
        private readonly IUserRepository userRepository;
        private readonly IBus bus;

        public SignUpHandler(IUserRepository userRepository,IBus bus)
        {
            this.userRepository = userRepository;
            this.bus = bus;
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
                var isMailExist = await userRepository.AnyAsync(user => user.Email == request.SignUpDtos.Email);
                if (isMailExist)
                {
                    return ApiResponse.BadRequest("EMail is exist");
                }
                if (!request.SignUpDtos.Password.Equals(request.SignUpDtos.ConfirmPassword))
                {
                    return ApiResponse.BadRequest("Password and confirm password are not the same");
                }
                var pass = Cryptography.EncryptPassword(request.SignUpDtos.Password);
                var user = new User { UserName = request.SignUpDtos.UserName, Email = request.SignUpDtos.Email, PasswordHash = pass.Hash, PasswordSalt = pass.Salt, RoleID = RoleConstants.IDUser };
                var result = await userRepository.CreateAsync(user);
                if (!result)
                {
                    return ApiResponse.InternalServerError();
                }
                CreateProfileEvent createProfileEvent = new CreateProfileEvent
                {
                    UserId = user.UserID,
                    FullName = request.SignUpDtos.FullName,
                    DateOfBirth = request.SignUpDtos.DateOfBirth,
                    Email= request.SignUpDtos.Email,
                    Gender = request.SignUpDtos.Gender
                };
                await bus.SendMessage<CreateProfileEvent>(createProfileEvent,ExchangeConstants.IdentityService);
                return ApiResponse.Created("Sign Up Success");
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}
