using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Model;
using Project.IdentityService.Dtos;

namespace Project.IdentityService.Commands
{
    public record SignInCommand(SignInDtos SignInDtos) : IRequest<ObjectResult>;
    public record SignUpCommand(SignUpDtos SignUpDtos) : IRequest<ObjectResult>;
    public record ProvideAccountCommand(ProvideAccount ProvideAccount, string Role) : IRequest<ObjectResult>;
    public record RefreshTokenCommand(TokenModel TokenModel) : IRequest<ObjectResult>;
    public record ChangePasswordCommand(ChangePasswordDtos ChangePasswordDtos,string UserID) : IRequest<ObjectResult>;
    public record ChangeStatusCommand(AccountStatusDtos AccountStatusDtos) : IRequest<ObjectResult>;
}
