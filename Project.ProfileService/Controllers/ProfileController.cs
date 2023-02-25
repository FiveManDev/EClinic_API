using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Constants;
using Project.Core.Authentication;
using Project.ProfileService.Commands;
using Project.ProfileService.Dtos.DoctorProfile;
using Project.ProfileService.Dtos.Profile;
using Project.ProfileService.Dtos.SupporterProfile;
using Project.ProfileService.Dtos.UserProfile;
using Project.ProfileService.Handlers.ProfileHandlers;
using Project.ProfileService.Queries;

namespace Project.ProfileService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProfileController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserProfilesByID(Guid UserID)
        {
            return await mediator.Send(new GetUserProfilesByIDQuery(UserID));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetDoctorProfileByID(Guid UserID)
        {
            return await mediator.Send(new GetDoctorProfileByIDQuery(UserID));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetSupporterProfileByID(Guid UserID)
        {
            return await mediator.Send(new GetSupporterProfileByIDQuery(UserID));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAdminProfileByID(Guid UserID)
        {
            return await mediator.Send(new GetProfileByIDQuery(UserID));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetExpertProfileByID(Guid UserID)
        {
            return await mediator.Send(new GetProfileByIDQuery(UserID));
        }
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetSimpleProfile(Guid UserID)
        {
            return await mediator.Send(new GetSimpleProfileQuery(UserID));
        }
        [HttpPost]
        [CustomAuthorize(Authorities = new[] { RoleConstants.User })]
        public async Task<IActionResult> CreateUserProfile([FromForm] CreateUserProfileDtos createUserProfileDtos)
        {
            return await mediator.Send(new CreateUserProfileCommands(createUserProfileDtos));
        }
        [HttpPost]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> CreateDoctorProfile([FromForm] CreateDoctorProfileDtos createDoctorProfileDtos)
        {
            return await mediator.Send(new CreateDoctorProfileCommands(createDoctorProfileDtos));
        }
        [HttpPost]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> CreateSupporterProfile([FromForm] CreateSupporterProfileDtos createSupporterProfileDtos)
        {
            return await mediator.Send(new CreateSupporterProfileCommands(createSupporterProfileDtos));
        }
        [HttpPost]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> CreateAdminProfile([FromForm] CreateProfileDtos createProfileDtos)
        {
            return await mediator.Send(new CreateProfileCommands(createProfileDtos));
        }
        [HttpPost]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> CreateExpertProfile([FromForm] CreateProfileDtos createProfileDtos)
        {
            return await mediator.Send(new CreateProfileCommands(createProfileDtos));
        }
        [HttpPut]
        [CustomAuthorize(Authorities = new[] { RoleConstants.User })]
        public async Task<IActionResult> UpdateUserProfile([FromForm] UpdateUserProfileDtos updateUserProfile)
        {
            return await mediator.Send(new UpdateUserProfileCommands(updateUserProfile));
        }
        [HttpPut]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> UpdateDoctorProfile([FromForm] UpdateDoctorProfileDtos updateDoctorProfileDtos)
        {
            return await mediator.Send(new UpdateDoctorProfileCommands(updateDoctorProfileDtos));
        }
        [HttpPut]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> UpdateSupporterProfile([FromForm] UpdateSupporterProfileDtos updateSupporterProfileDtos)
        {
            return await mediator.Send(new UpdateSupporterProfileCommands(updateSupporterProfileDtos));
        }
        [HttpPut]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> UpdateAdminProfile([FromForm] UpdateProfileDtos updateProfileDtos)
        {
            return await mediator.Send(new UpdateProfileCommands(updateProfileDtos));
        }
        [HttpPut]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> UpdateExpertProfile([FromForm] UpdateProfileDtos updateProfileDtos)
        {
            return await mediator.Send(new UpdateProfileCommands(updateProfileDtos));
        }
        [HttpDelete]
        [CustomAuthorize(Authorities = new[] { RoleConstants.User })]
        public async Task<IActionResult> DeleteUserProfile(Guid ProfileID)
        {
            return await mediator.Send(new DeleteUserProfileCommands(ProfileID));
        }
        [HttpDelete]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> DeleteDoctorProfile(Guid ProfileID)
        {
            return await mediator.Send(new DeleteDoctorProfileCommands(ProfileID));
        }
        [HttpDelete]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> DeleteSupporterProfile(Guid ProfileID)
        {
            return await mediator.Send(new DeleteSupporterProfileCommands(ProfileID));
        }
        [HttpDelete]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> DeleteAdminProfile(Guid ProfileID)
        {
            return await mediator.Send(new DeleteProfileCommands(ProfileID));
        }
        [HttpDelete]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> DeleteExpertProfile(Guid ProfileID)
        {
            return await mediator.Send(new DeleteProfileCommands(ProfileID));
        }
    }
}
