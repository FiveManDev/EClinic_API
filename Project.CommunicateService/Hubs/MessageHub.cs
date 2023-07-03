using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Project.CommunicateService.Hubs
{
    public class MessageHub : Hub
    {
        [Authorize]
        public async Task JoinGroup(Guid RoomID)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, RoomID.ToString());
        }
        [Authorize]
        public async Task LeaveGroup(Guid RoomID)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, RoomID.ToString());
        }
        [Authorize]
        public async Task JoinCall(string CallID)
        {
            string userId = Context.User.FindFirst("UserID").Value;
            await Groups.AddToGroupAsync(Context.ConnectionId, CallID);
            await Clients.Group(CallID).SendAsync("Response", "JoinRoom", userId);
        }
        [Authorize]
        public async Task LeaveCall(string CallID)
        {
            string userId = Context.User.FindFirst("UserID").Value;
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, CallID);
            await Clients.Group(CallID).SendAsync("Response", "LeaveGroup", userId);
        }
    }
}
