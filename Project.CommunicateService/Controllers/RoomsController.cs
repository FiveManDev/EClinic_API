using Microsoft.AspNetCore.Mvc;

namespace Project.CommunicateService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class RoomsController : ControllerBase
    {
        
    }
}
