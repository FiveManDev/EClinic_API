using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Project.CommunicateService.Data;

namespace Project.CommunicateService.Hubs
{
    public class MessageHub : Hub
    {
        [Authorize]
        public async Task JoinGroup(Guid RoomID)
        {
            await Console.Out.WriteLineAsync(MessageType.Text.ToString());
            string userId = Context.User.FindFirst("UserID").Value;
            await Groups.AddToGroupAsync(Context.ConnectionId, RoomID.ToString());
            await Clients.Group(RoomID.ToString()).SendAsync("Response", "JoinRoom", userId);
        }
        [Authorize]
        public async Task LeaveGroup(Guid RoomID)
        {
            string userId = Context.User.FindFirst("UserID").Value;
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, RoomID.ToString());
            await Clients.Group(RoomID.ToString()).SendAsync("Response", "LeaveGroup", userId);
        }
    }
}
