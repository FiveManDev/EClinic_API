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
        public async Task JoinCall(string CallID, Guid RoomID)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, CallID);
            await Clients.Group(RoomID.ToString()).SendAsync("Response", "peerId", CallID);
        }
        [Authorize]
        public async Task ChangeCallStatus(string CallID, int status)
        {
            await Clients.Group(CallID).SendAsync("Response", "Status", status, CallID);
        }
    }
}
