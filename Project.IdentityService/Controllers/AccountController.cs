﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Constants;
using Project.Common.Enum;
using Project.Common.Functionality;
using Project.Common.Response;
using Project.Common.Security;
using Project.Core.Authentication;
using Project.Core.Filters;
using Project.IdentityService.Commands;
using Project.IdentityService.Data;
using Project.IdentityService.Dtos;
using Project.IdentityService.Repository.UserRepository;

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
        public async Task<IActionResult> ProvideDoctorAccount(ProvideAccount provideAccount)
        {
            return await mediator.Send(new ProvideAccountCommand(provideAccount, RoleConstants.IDDoctor));

        }
        [HttpPost]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> ProvideSupportAccount(ProvideAccount provideAccount)
        {
            return await mediator.Send(new ProvideAccountCommand(provideAccount, RoleConstants.IDSupporter));

        }
        [HttpPost]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        public async Task<IActionResult> ProvideAdminAccount(ProvideAccount provideAccount)
        {

            return await mediator.Send(new ProvideAccountCommand(provideAccount, RoleConstants.IDAdmin));
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDtos changePasswordDtos)
        {
            string userId = User.Claims.FirstOrDefault(claim => claim.Type == "UserID").Value;
            if (userId == null)
            {
                return ApiResponse.NotFound("Account not found.");
            }
            return await mediator.Send(new ChangePasswordCommand(changePasswordDtos, userId));
        }
        [HttpPut]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        [ServiceFilter(typeof(NotFoundIdFilter<IUserRepository, User>))]
        public async Task<IActionResult> ChangeStatus([FromBody] AccountStatusDtos accountStatusDtos)
        {
            return await mediator.Send(new ChangeStatusCommand(accountStatusDtos));
        }

    }
}
