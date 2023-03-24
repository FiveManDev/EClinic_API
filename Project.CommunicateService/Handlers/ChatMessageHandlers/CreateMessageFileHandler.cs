using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Enum;
using Project.Common.Response;
using Project.CommunicateService.Commands;
using Project.CommunicateService.Data;
using Project.CommunicateService.Repository.ChatMessageRepositories;
using Project.Core.AWS;
using Project.Core.Logger;

namespace Project.CommunicateService.Handlers.ChatMessageHandlers
{
    public class CreateMessageFileHandler : IRequestHandler<CreateMessageFileCommand, ObjectResult>
    {
        private readonly IChatMessageRepository repository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly ILogger<CreateMessageFileHandler> logger;

        public CreateMessageFileHandler(IChatMessageRepository repository, IAmazonS3Bucket s3Bucket, ILogger<CreateMessageFileHandler> logger)
        {
            this.repository = repository;
            this.s3Bucket = s3Bucket;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(CreateMessageFileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var UserID = Guid.Parse(request.UserID);
                var url = await s3Bucket.UploadFileAsync(request.CreateMassageFileDtos.File, FileType.Image);
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
