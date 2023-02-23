using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Project.NotificationService.Commands
{
    public record VerifyEmailCommand(string email) : IRequest<ObjectResult>;
    public record ConfirmEmailCommand(string email) : IRequest<ObjectResult>;
}
