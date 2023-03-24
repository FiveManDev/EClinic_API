using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.CommunicateService.Data;
using Project.CommunicateService.Dtos.ChatMessageDtos;
using Project.CommunicateService.Dtos.VideoCallDtos;

namespace Project.CommunicateService.Commands
{
    public record CreateMessageCommand(string UserID, CreateMessageDtos CreateMassageDtos) : IRequest<ObjectResult>;
    public record CreateMessageFileCommand(string UserID, CreateMessageFileDtos CreateMassageFileDtos) : IRequest<ObjectResult>;
    public record CreateVideoCallCommand(CreateVideoCallDtos CreateVideoCallDtos) : IRequest<ObjectResult>;
    public record DeleteVideoCallCommand(Guid VideoCallID) : IRequest<ObjectResult>;
    public record CreateRoomCommand(Guid RoomTypeID) : IRequest<ObjectResult>;
}
