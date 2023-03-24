using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.CommunicateService.Commands;
using Project.CommunicateService.Data;
using Project.CommunicateService.Repository.VideoCallRepositories;
using Project.Core.AWS;
using Project.Core.Logger;

namespace Project.CommunicateService.Handlers.VideoCallHandlers
{
    public class DeleteVideoCallHandler : IRequestHandler<DeleteVideoCallCommand, ObjectResult>
    {
        private readonly IVideoCallRepository videoCallRepository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly ILogger<DeleteVideoCallHandler> logger;

        public DeleteVideoCallHandler(IVideoCallRepository videoCallRepository, IAmazonS3Bucket s3Bucket, ILogger<DeleteVideoCallHandler> logger)
        {
            this.videoCallRepository = videoCallRepository;
            this.s3Bucket = s3Bucket;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(DeleteVideoCallCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var VideoCall = await videoCallRepository.GetAsync(request.VideoCallID);
                if (VideoCall == null)
                {
                    return ApiResponse.NotFound("Video Call Not Found");
                }
                var result = await videoCallRepository.DeleteAsync(VideoCall);
                if (!result)
                {
                    throw new Exception("Delete Video Call Success.");
                }
                await s3Bucket.DeleteFileAsync(VideoCall.VideoUrl);
                return ApiResponse.OK("Delete Video Call Success");
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
