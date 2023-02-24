using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Constants;
using Project.Core.Authentication;
using Project.Core.Caching.Attributes;
using Project.IdentityService.Queries;

namespace Project.IdentityService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator mediator;

        public RoleController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [CustomAuthorize(Authorities = new[] { RoleConstants.Admin })]
        [Cache(1000)]
        public async Task<IActionResult> GetAll()
        {
            return await mediator.Send(new GetAllRoleQuery());
        }
    }
}
