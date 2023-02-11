using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Model;
using Project.IdentityService.Dtos;
using Project.IdentityService.Protos;

namespace Project.IdentityService.Commands
{
    public record SignInCommand(SignInDtos SignInDtos) : IRequest<ObjectResult>;
    public record SignUpCommand(SignUpDtos SignUpDtos) : IRequest<ObjectResult>;
    public record ProvideAccountCommand(Guid UserID) : IRequest<ObjectResult>;
    public record ProvideAccountWithRoleCommand(string Email, string Role) : IRequest<AccountResponse>;
    public record RefreshTokenCommand(string RefreshToken) : IRequest<ObjectResult>;
    public record ChangePasswordCommand(ChangePasswordDtos ChangePasswordDtos, string UserID) : IRequest<ObjectResult>;
    public record ResetPasswordCommand(ResetPasswordDTO ResetPasswordDTO) : IRequest<ObjectResult>;
    public record ChangeStatusCommand(Guid UserID) : IRequest<ObjectResult>;
}
