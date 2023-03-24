using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.CommunicateService.Commands;
using Project.CommunicateService.Data;
using Project.CommunicateService.Repository.ChatMessageRepositories;
using Project.Core.Logger;

namespace Project.CommunicateService.Handlers.ChatMessageHandlers
{
    public class CreateMessageHandler : IRequestHandler<CreateMessageCommand, ObjectResult>
    {
        private readonly IChatMessageRepository repository;
        private readonly ILogger<CreateMessageHandler> logger;

        public CreateMessageHandler(IChatMessageRepository repository, ILogger<CreateMessageHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            try
            {
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
                return ApiResponse.Created("Create Success");
            }
            catch(Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
