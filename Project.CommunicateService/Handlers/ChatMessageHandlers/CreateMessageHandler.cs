using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Project.Common.Response;
using Project.CommunicateService.Commands;
using Project.CommunicateService.Data;
using Project.CommunicateService.Dtos.ChatMessageDtos;
using Project.CommunicateService.Hubs;
using Project.CommunicateService.Repository.ChatMessageRepositories;
using Project.CommunicateService.Repository.RoomRepositories;
using Project.Core.Logger;

namespace Project.CommunicateService.Handlers.ChatMessageHandlers
{
    public class CreateMessageHandler : IRequestHandler<CreateMessageCommand, ObjectResult>
    {
        private readonly IChatMessageRepository repository;
        private readonly ILogger<CreateMessageHandler> logger;
        private readonly IRoomRepository roomRepository;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        public CreateMessageHandler(IChatMessageRepository repository, ILogger<CreateMessageHandler> logger, IRoomRepository roomRepository, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.roomRepository = roomRepository;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        public async Task<ObjectResult> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Room = await roomRepository.GetAsync(request.CreateMassageDtos.RoomID);
                if (Room.IsClosed)
                {
                    return ApiResponse.BadRequest("Room is close");
                }
                var UserID = Guid.Parse(request.UserID);
                var ChatMessage = new ChatMessage
                {
                    UserID = UserID,
                    Content = request.CreateMassageDtos.Content,
                    CreatedAt = DateTime.Now,
                    RoomID = request.CreateMassageDtos.RoomID,
                    Type = MessageType.Text
                };
                var result = await repository.CreateAsync(ChatMessage);
                if (!result)
                {
                    throw new Exception("Create chat message error.");
                }
                var chatDtos = mapper.Map<ChatMessageDto>(ChatMessage);
                await hubContext.Clients.Group(ChatMessage.RoomID.ToString()).SendAsync("Response", chatDtos);
                return ApiResponse.Created("Create Success");
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
