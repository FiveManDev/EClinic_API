using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Project.ProfileService.Commands
{
    public record CreateProfileCommands() : IRequest<ObjectResult>;
}