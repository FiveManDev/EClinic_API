using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Caching.Attributes;
using Project.Core.Model;
using Project.IdentityService.Commands;
using Project.IdentityService.Data;
using Project.IdentityService.Dtos;

namespace Project.IdentityService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthenticationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDtos signInDtos)
        {
            return await mediator.Send(new SignInCommand(signInDtos));
        }
        [HttpGet]
        public async Task<IActionResult> RefreshToken([FromHeader] TokenModel Token)
        {
            return await mediator.Send(new RefreshTokenCommand(Token));
        }
        [HttpGet]
        [Cache(1000)]
        public async Task<IActionResult> GetID()
        {
            await Task.CompletedTask; 
            return ApiResponse.OK<User>(new Data.User
            {
                UserName = "Khang"
            });
        }
    }
}
