using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Constants;
using Project.Core.Authentication;
using Project.IdentityService.Commands;
using Project.IdentityService.Dtos;

namespace Project.IdentityService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDtos signUpDtos)
        {
            return await mediator.Send(new SignUpCommand(signUpDtos));
        }
        [HttpPost]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> ProvideDoctorAccount([FromBody] Guid ProfileID)
        {
            return await mediator.Send(new ProvideAccountCommand(ProfileID, RoleConstants.IDUser));

        }
        [HttpPost]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> ProvideSupporterAccount([FromBody] Guid ProfileID)
        {
            return await mediator.Send(new ProvideAccountCommand(ProfileID, RoleConstants.IDSupporter));

        }
        [HttpPost]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> ProvideAdminAccount([FromBody] Guid ProfileID)
        {
            return await mediator.Send(new ProvideAccountCommand(ProfileID, RoleConstants.IDAdmin));

        }
        [HttpPost]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> ProvideExpertAccount([FromBody] Guid ProfileID)
        {
            return await mediator.Send(new ProvideAccountCommand(ProfileID, RoleConstants.IDExpert));

        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDtos changePasswordDtos)
        {
            string userId = User.Claims.FirstOrDefault(claim => claim.Type == "UserID").Value;
            return await mediator.Send(new ChangePasswordCommand(changePasswordDtos, userId));
        }
        [HttpPut]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> ChangeStatus(Guid UserID)
        {
            return await mediator.Send(new ChangeStatusCommand(UserID));
        }

    }
}
