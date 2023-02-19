using Amazon.S3.Model;
using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Constants;
using Project.Common.Enum;
using Project.Common.Response;
using Project.Core.Logger;
using Project.Core.RabbitMQ;
using Project.ProfileService.Dtos.Profile;
using Project.ProfileService.Events;
using Project.ProfileService.Queries;
using Project.ProfileService.Repository.ProfileRepository;

namespace Project.ProfileService.Handlers.ProfileHandlers
{
    public class GetSimpleProfileHandler : IRequestHandler<GetSimpleProfileQuery, ObjectResult>
    {
        private readonly IProfileRepository profileRepository;
        private readonly IMapper mapper;
        private readonly ILogger<GetSimpleProfileHandler> logger;
        private readonly IBus bus;

        public GetSimpleProfileHandler(IProfileRepository profileRepository, IMapper mapper, ILogger<GetSimpleProfileHandler> logger, IBus bus)
        {
            this.profileRepository = profileRepository;
            this.mapper = mapper;
            this.logger = logger;
            this.bus = bus;
        }

        public async Task<ObjectResult> Handle(GetSimpleProfileQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var profile = await profileRepository.GetAsync(request.ProfileID);
                if (profile == null)
                {
                    return ApiResponse.NotFound("Profile Not Found.");
                }
                var sampleProfile = mapper.Map<SimpleProfileDtos>(profile);
                await bus.SendMessage<DeleteProfileEvents>(new DeleteProfileEvents { UserID = request.ProfileID }, ExchangeConstants.IdentityService);
                return ApiResponse.OK<SimpleProfileDtos>(sampleProfile);
                
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
