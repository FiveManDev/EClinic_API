using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Project.CommunicateService.Commands
{
    public record CreateMessageCommand(Guid RoomID) : IRequest<ObjectResult>;
    public record CreateMessageFileCommand(Guid RoomID) : IRequest<ObjectResult>;
    public record CreateVideoCallCommand(Guid RoomID) : IRequest<ObjectResult>;
    public record DeleteVideoCallCommand(Guid RoomID) : IRequest<ObjectResult>;
    public record CreateRoomCommand() : IRequest<ObjectResult>;
    public record DeleteRoomCommand(Guid RoomID) : IRequest<ObjectResult>;
}
