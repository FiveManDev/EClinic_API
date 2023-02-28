using AutoMapper;
using Grpc.Net.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Common.Constants;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.ProfileService.Dtos.EmployeeProfile;
using Project.ProfileService.Dtos.UserProfile;
using Project.ProfileService.Helpers;
using Project.ProfileService.Protos;
using Project.ProfileService.Queries;
using Project.ProfileService.Repository.ProfileRepository;

namespace Project.ProfileService.Handlers.UserProfileHandlers
{
    public class GetEmployeeProfileHandler : IRequestHandler<GetEmployeeProfileQuery, ObjectResult>
    {
        private readonly IProfileRepository profileRepository;
        private readonly ILogger<GetEmployeeProfileHandler> logger;
        private readonly IAmazonS3Bucket bucket;
        private readonly UserService.UserServiceClient client;
        private readonly IMapper mapper;
        public GetEmployeeProfileHandler(IConfiguration configuration, IProfileRepository profileRepository, ILogger<GetEmployeeProfileHandler> logger, IAmazonS3Bucket bucket, IMapper mapper)
        {
            this.profileRepository = profileRepository;
            this.logger = logger;
            this.bucket = bucket;
            this.mapper = mapper;
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            GrpcChannel channel = GrpcChannel.ForAddress(configuration.GetValue<string>("GrpcSettings:IdentityServiceUrl"), new GrpcChannelOptions { HttpHandler = httpHandler });
            client = new UserService.UserServiceClient(channel);
        }
        public async Task<ObjectResult> Handle(GetEmployeeProfileQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await client.GetAllUserWithRoleAsync(new GetAllUserWithRoleRequest { Role = request.Role });
                var ListUserID = res.UserIDs.ToList();
                List<Guid> listID = ListUserID.Select(s => Guid.Parse(s)).ToList();
                var pagination = await profileRepository.GetEmployeeProfilesAsync(listID, request.PaginationRequestHeader, request.SearchText);
                request.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination.PaginationResponseHeader));
                var profileDtos = mapper.Map<List<GetEmployeeProfileDtos>>(pagination.PaginationData);
                foreach (var profile in profileDtos)
                {
                    profile.Avatar = await bucket.GetUrl(profile.Avatar);
                }
                return ApiResponse.OK<List<GetEmployeeProfileDtos>>(profileDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
