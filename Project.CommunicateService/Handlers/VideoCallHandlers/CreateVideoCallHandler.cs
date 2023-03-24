using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Enum;
using Project.Common.Response;
using Project.CommunicateService.Commands;
using Project.CommunicateService.Data;
using Project.CommunicateService.Repository.VideoCallRepositories;
using Project.Core.AWS;
using Project.Core.Logger;

namespace Project.CommunicateService.Handlers.VideoCallHandlers
{
    public class CreateVideoCallHandler : IRequestHandler<CreateVideoCallCommand, ObjectResult>
    {
        private readonly IVideoCallRepository videoCallRepository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly ILogger<CreateVideoCallHandler> logger;

        public CreateVideoCallHandler(IVideoCallRepository videoCallRepository, IAmazonS3Bucket s3Bucket, ILogger<CreateVideoCallHandler> logger)
        {
            this.videoCallRepository = videoCallRepository;
            this.s3Bucket = s3Bucket;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(CreateVideoCallCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var url = await s3Bucket.UploadFileAsync(request.CreateVideoCallDtos.Video, FileType.Video);
                var VideoCall = new VideoCall
                {
                    VideoUrl = url,
                    StartTime = request.CreateVideoCallDtos.StartTime,
                    EndTime = request.CreateVideoCallDtos.EndTime,
                    RoomID = request.CreateVideoCallDtos.RoomID
                };
                var result = await videoCallRepository.CreateAsync(VideoCall);
                if (!result)
                {
                    throw new Exception("Create Video Call Error.");
                }
                return ApiResponse.Created("Create Video Call Success.");
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
