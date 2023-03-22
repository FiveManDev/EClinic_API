using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;

namespace Project.CommunicateService.Queries
{
    public record GetAllMessageOfRoomQuery(PaginationRequestHeader PaginationRequestHeader, HttpResponse Response, Guid RoomID) : IRequest<ObjectResult>;
    public record GetAllRoomOfRoomTypeQuery(PaginationRequestHeader PaginationRequestHeader, HttpResponse Response, Guid RoomTypeID) : IRequest<ObjectResult>;
    public record GetAllRoomTypeQuery() : IRequest<ObjectResult>;
}
