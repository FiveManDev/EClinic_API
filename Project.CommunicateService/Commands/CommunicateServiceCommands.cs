using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.CommunicateService.Dtos.ChatMessageDtos;

namespace Project.CommunicateService.Commands
{
    public record CreateMessageCommand(string UserID, CreateMessageDtos CreateMassageDtos) : IRequest<ObjectResult>;
    public record CreateMessageFileCommand(string UserID, CreateMessageFileDtos CreateMassageFileDtos) : IRequest<ObjectResult>;
    public record CreateSupporterRoomCommand(string Message,string UserID) : IRequest<ObjectResult>;
    public record CreateDoctorRoomCommand() : IRequest<ObjectResult>;
    public record CloseRoomCommand(Guid RoomID) : IRequest<ObjectResult>;
}
