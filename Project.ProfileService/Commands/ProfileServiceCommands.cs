using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.ProfileService.Dtos.DoctorProfile;
using Project.ProfileService.Dtos.Profile;
using Project.ProfileService.Dtos.SupporterProfile;
using Project.ProfileService.Dtos.UserProfile;

namespace Project.ProfileService.Commands
{
    public record CreateUserProfileCommands(CreateUserProfileDtos CreateUserProfileDtos) : IRequest<ObjectResult>;
    public record CreateDoctorProfileCommands(CreateDoctorProfileDtos CreateDoctorProfileDtos) : IRequest<ObjectResult>;
    public record CreateSupporterProfileCommands(CreateSupporterProfileDtos CreateSupporterProfileDtos) : IRequest<ObjectResult>;
    public record CreateProfileCommands(CreateProfileDtos CreateProfileDtos) : IRequest<ObjectResult>;
    public record UpdateProfileCommands(UpdateProfileDtos UpdateProfileDtos) : IRequest<ObjectResult>;
    public record UpdateDoctorProfileCommands(UpdateDoctorProfileDtos UpdateDoctorProfileDtos) : IRequest<ObjectResult>;
    public record UpdateSupporterProfileCommands(UpdateSupporterProfileDtos UpdateSupporterProfileDtos) : IRequest<ObjectResult>;
    public record UpdateUserProfileCommands(UpdateUserProfileDtos UpdateUserProfileDtos) : IRequest<ObjectResult>;
    public record DeleteProfileCommands(Guid ProfileID) : IRequest<ObjectResult>;
    public record DeleteDoctorProfileCommands(Guid ProfileID) : IRequest<ObjectResult>;
    public record DeleteSupporterProfileCommands(Guid ProfileID) : IRequest<ObjectResult>;
    public record DeleteUserProfileCommands(Guid ProfileID) : IRequest<ObjectResult>;

}