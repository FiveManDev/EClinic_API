using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Common.Security;
using Project.IdentityService.Commands;
using Project.IdentityService.Repository.UserRepository;
namespace Project.IdentityService.Handlers.Account
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, ObjectResult>
    {
        private readonly IUserRepository userRepository;

        public ChangePasswordHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ObjectResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.ChangePasswordDtos.NewPassword.Equals(request.ChangePasswordDtos.ConfirmPassword))
                {
                    return ApiResponse.BadRequest("New password and confirm password are not the same.");
                }

                var user = await userRepository.GetAsync(Guid.Parse(request.UserID));
                if (user == null)
                {
                    return ApiResponse.NotFound("Account not found.");
                }

                if (Cryptography.VerifyPassword(request.ChangePasswordDtos.OldPassword, user.PasswordSalt, user.PasswordHash))
                {
                    var passwordModel = Cryptography.EncryptPassword(request.ChangePasswordDtos.NewPassword);

                    user.PasswordSalt = passwordModel.Salt;
                    user.PasswordHash = passwordModel.Hash;
                    user.UpdateAt = DateTime.Now;

                    var result = await userRepository.UpdateAsync(user);

                    if (!result)
                    {
                        throw new Exception("Save data of User failed");
                    }
                    return ApiResponse.OK("Change password success");
                }
                else
                {
                    return ApiResponse.BadRequest("Incorrect password!");
                }
            }
            catch
            {

                return ApiResponse.InternalServerError();
            }
        }
    }
}
