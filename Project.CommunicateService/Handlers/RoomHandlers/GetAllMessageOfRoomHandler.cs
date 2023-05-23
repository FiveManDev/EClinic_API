using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;
using Project.Common.Response;
using Project.CommunicateService.Commands;
using Project.CommunicateService.Data;
using Project.CommunicateService.Dtos.ChatMessageDtos;
using Project.CommunicateService.Dtos.VideoCallDtos;
using Project.CommunicateService.Queries;
using Project.CommunicateService.Repository.RoomRepositories;
using Project.Core.AWS;
using Project.Core.Logger;

namespace Project.CommunicateService.Handlers.RoomHandlers
{
    public class GetAllMessageOfRoomHandler : IRequestHandler<GetAllMessageOfRoomQuery, ObjectResult>
    {
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;
        private readonly ILogger<GetAllMessageOfRoomHandler> logger;

        public GetAllMessageOfRoomHandler(IRoomRepository roomRepository, IMapper mapper, ILogger<GetAllMessageOfRoomHandler> logger)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(GetAllMessageOfRoomQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var UserID = Guid.Parse(request.UserID);
                var Room = await roomRepository.GetRoom(request.RoomID);
                if (Room == null)
                {
                    return ApiResponse.NotFound("Room Not Found");
                }
                var ChatMessages = Room.ChatMessages;
                PaginationResponseHeader header = new PaginationResponseHeader();
                header.TotalCount = ChatMessages.Count;
                ChatMessages = ChatMessages
                    .OrderBy(x => x.CreatedAt)
                    .Skip((request.PaginationRequestHeader.PageNumber - 1) * request.PaginationRequestHeader.PageSize)
                    .Take(request.PaginationRequestHeader.PageSize).ToList();
                var VideoCall = Room.VideoCalls;
                var ChatMessageDtos = mapper.Map<List<ChatMessageDtos>>(ChatMessages);
                var VideoCallDtos = mapper.Map<List<VideoCallDtos>>(VideoCall);
                foreach (var chatMessage in ChatMessageDtos)
                {
                    if (chatMessage.Type == MessageType.Image)
                    {
                        chatMessage.IsImage = true;
                    }
                    if(chatMessage.UserID == UserID)
                    {
                        chatMessage.IsMyChat = true;
                    }
                }
                return ApiResponse.OK<List<ChatMessageDtos>>(ChatMessageDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
