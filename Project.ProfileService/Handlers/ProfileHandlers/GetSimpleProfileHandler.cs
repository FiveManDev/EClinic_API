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

        public GetSimpleProfileHandler(IProfileRepository profileRepository, IMapper mapper, ILogger<GetSimpleProfileHandler> logger)
        {
            this.profileRepository = profileRepository;
            this.mapper = mapper;
            this.logger = logger;
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
