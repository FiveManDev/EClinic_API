using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Project.Common.Enum;
using Project.Common.Response;
using Project.CommunicateService.Commands;
using Project.CommunicateService.Data;
using Project.CommunicateService.Dtos.ChatMessageDtos;
using Project.CommunicateService.Hubs;
using Project.CommunicateService.Repository.ChatMessageRepositories;
using Project.CommunicateService.Repository.RoomRepositories;
using Project.Core.AWS;
using Project.Core.Logger;

namespace Project.CommunicateService.Handlers.ChatMessageHandlers
{
    public class CreateMessageFileHandler : IRequestHandler<CreateMessageFileCommand, ObjectResult>
    {
        private readonly IChatMessageRepository repository;
        private readonly IRoomRepository roomRepository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly ILogger<CreateMessageFileHandler> logger;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper mapper;

        public CreateMessageFileHandler(IChatMessageRepository repository, IRoomRepository roomRepository, IAmazonS3Bucket s3Bucket, ILogger<CreateMessageFileHandler> logger, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            this.repository = repository;
            this.roomRepository = roomRepository;
            this.s3Bucket = s3Bucket;
            this.logger = logger;
            this.hubContext = hubContext;
            this.mapper = mapper;
        }

        public async Task<ObjectResult> Handle(CreateMessageFileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Room = await roomRepository.GetAsync(request.CreateMassageFileDtos.RoomID);
                if (Room.IsClosed)
                {
                    return ApiResponse.BadRequest("Room is close");
                }
                var UserID = Guid.Parse(request.UserID);
                var url = await s3Bucket.UploadFileAsync(request.CreateMassageFileDtos.File, FileType.Image);
                if (url == null)
                {
                    return ApiResponse.BadRequest("Server AWS CHậm mày ơi");
                }
                var ChatMessage = new ChatMessage
                {
                    UserID = UserID,
                    Content = url,
                    CreatedAt = DateTime.Now,
                    RoomID = request.CreateMassageFileDtos.RoomID,
                    Type = MessageType.Image
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
