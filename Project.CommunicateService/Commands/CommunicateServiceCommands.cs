using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.CommunicateService.Dtos.ChatMessageDtos;

namespace Project.CommunicateService.Commands
{
    public record CreateMessageCommand(string UserID, CreateMessageDtos CreateMassageDtos) : IRequest<ObjectResult>;
    public record CreateMessageFileCommand(string UserID, CreateMessageFileDtos CreateMassageFileDtos) : IRequest<ObjectResult>;
    public record CreateRoomCommand(Guid RoomTypeID) : IRequest<ObjectResult>;
    public record CloseRoomCommand(Guid RoomID) : IRequest<ObjectResult>;
}
