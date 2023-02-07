using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.ForumService.Commands;
using Project.ForumService.Dtos.AnswersDtos;
using Project.ForumService.Queries;

namespace Project.ForumService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class AnswerController : ControllerBase
    {
        private readonly IMediator mediator;

        public AnswerController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        //[CustomAuthorize(Authorities = new[] { RoleConstants.Admin, RoleConstants.Doctor, RoleConstants.User, RoleConstants.Supporter })]
        public async Task<IActionResult> GetAnswerByID(Guid PostID)
        {
            string userId = User.Claims.FirstOrDefault(claim => claim.Type == "UserID").Value;
            return await mediator.Send(new GetAnswerQuery(PostID, userId));
        }
        [HttpPost]
        //[CustomAuthorize(Authorities = new[] { RoleConstants.User })]
        public async Task<IActionResult> CreateAnswer([FromBody] CreateAnswerDtos createAnswerDtos)
        {
            return await mediator.Send(new CreateAnswerCommands(createAnswerDtos));
        }
        [HttpPut]
        //[CustomAuthorize(Authorities = new[] { RoleConstants.User })]
        public async Task<IActionResult> UpdateAnswer([FromBody] UpdateAnswerDtos updateAnswerDtos)
        {
            return await mediator.Send(new UpdateAnswerCommands(updateAnswerDtos));
        }
        [HttpDelete]
        //[CustomAuthorize(Authorities = new[] { RoleConstants.Admin, RoleConstants.User })]
        public async Task<IActionResult> DeleteAnswerByID(Guid AnswerID)
        {
            return await mediator.Send(new DeleteAnswerCommands(AnswerID));
        }
        [HttpPut]
        //[CustomAuthorize(Authorities = new[] { RoleConstants.Admin, RoleConstants.Doctor, RoleConstants.User })]
        public async Task<IActionResult> LikeAnswer(Guid AnswerID)
        {
            string userId = User.Claims.FirstOrDefault(claim => claim.Type == "UserID").Value;
            return await mediator.Send(new LikeAnswerCommands(AnswerID, userId));
        }
    }
}
