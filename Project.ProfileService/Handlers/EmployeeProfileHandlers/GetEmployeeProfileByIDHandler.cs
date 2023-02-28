using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.ProfileService.Queries;
using Project.ProfileService.Repository.ProfileRepository;

namespace Project.ProfileService.Handlers.EmployeeProfileHandlers
{
    public class GetEmployeeProfileByIDHandler : IRequestHandler<GetEmployeeProfileByIDQuery, ObjectResult>
    {
        private readonly ILogger<GetEmployeeProfileByIDHandler> logger;
        private readonly IProfileRepository repository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly IMapper mapper;

        public GetEmployeeProfileByIDHandler(ILogger<GetEmployeeProfileByIDHandler> logger, IProfileRepository repository, IAmazonS3Bucket s3Bucket, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.s3Bucket = s3Bucket;
            this.mapper = mapper;
        }

        public async Task<ObjectResult> Handle(GetEmployeeProfileByIDQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var supporterProfiles = await repository.GetSupporterProfileAsync(request.UserID);
                if (supporterProfiles == null)
                {
                    return ApiResponse.NotFound("Profile Not Found.");
                }
                var supporteProfileDtos = mapper.Map<CreateEmployeeProfileProfileDtos>(supporterProfiles);
                //supporteProfileDtos.Avatar = await s3Bucket.GetUrl(supporteProfileDtos.Avatar);
                return ApiResponse.OK<CreateEmployeeProfileProfileDtos>(supporteProfileDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
