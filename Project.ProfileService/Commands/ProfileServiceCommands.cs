using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.ProfileService.Dtos.UserProfile;

namespace Project.ProfileService.Commands
{
    public record CreateUserProfileCommands(CreateUserProfileDtos CreateUserProfileDtos) : IRequest<ObjectResult>;
    public record CreateDoctorProfileCommands() : IRequest<ObjectResult>;
    public record CreateSupporterProfileCommands() : IRequest<ObjectResult>;
    public record CreateAdminProfileCommands() : IRequest<ObjectResult>;
}