using MassTransit.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Project.CommunicateService.Hubs
{
    public class MessageHub : Hub
    {
        //private readonly IMediator mediator;
        //private readonly ILogger<MessageHub> logger;
        //public MessageHub(IMediator mediator, ILogger<MessageHub> logger)
        //{
        //    this.mediator = mediator;
        //    this.logger = logger;
        //}

        [Authorize]
        public async Task JoinGroup(Guid RoomID,Guid UserID)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, RoomID.ToString());
            await Clients.Group(RoomID.ToString()).SendAsync("Response", "JoinRoom", UserID);
        }
    }
}
