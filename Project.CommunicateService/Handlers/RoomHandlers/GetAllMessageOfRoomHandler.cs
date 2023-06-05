using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Common.Paging;
using Project.Common.Response;
using Project.CommunicateService.Data;
using Project.CommunicateService.Dtos.ChatMessageDtos;
using Project.CommunicateService.Queries;
using Project.CommunicateService.Repository.RoomRepositories;
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
                    .OrderByDescending(x => x.CreatedAt)
                    .Skip((request.PaginationRequestHeader.PageNumber - 1) * request.PaginationRequestHeader.PageSize)
                    .Take(request.PaginationRequestHeader.PageSize).ToList();
                header.PageIndex = request.PaginationRequestHeader.PageNumber;
                header.PageSize = request.PaginationRequestHeader.PageSize;
                var ChatMessageDtos = mapper.Map<List<ChatMessageDto>>(ChatMessages);
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
                request.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(header));
                ChatMessageDtos = ChatMessageDtos.OrderBy(x => x.CreatedAt).ToList();
                return ApiResponse.OK<List<ChatMessageDto>>(ChatMessageDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
