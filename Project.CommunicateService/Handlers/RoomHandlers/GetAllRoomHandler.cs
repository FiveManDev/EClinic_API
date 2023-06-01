using AutoMapper;
using Grpc.Net.Client;
using MassTransit.Initializers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Common.Paging;
using Project.Common.Response;
using Project.CommunicateService.Data;
using Project.CommunicateService.Dtos.RoomDtos;
using Project.CommunicateService.Protos;
using Project.CommunicateService.Queries;
using Project.CommunicateService.Repository.ChatMessageRepositories;
using Project.CommunicateService.Repository.RoomRepositories;
using Project.Core.Logger;

namespace Project.CommunicateService.Handlers.RoomHandlers
{
    public class GetAllRoomHandler : IRequestHandler<GetAllRoomQuery, ObjectResult>
    {
        private readonly IRoomRepository roomRepository;
        private readonly IChatMessageRepository chatMessageRepository;
        private readonly IMapper mapper;
        private readonly ProfileService.ProfileServiceClient client;
        private readonly ILogger<GetAllRoomHandler> logger;

        public GetAllRoomHandler(IConfiguration configuration, IRoomRepository roomRepository, IMapper mapper, ILogger<GetAllRoomHandler> logger, IChatMessageRepository chatMessageRepository)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
            this.logger = logger;
            this.chatMessageRepository = chatMessageRepository;
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            GrpcChannel channel = GrpcChannel.ForAddress(configuration.GetValue<string>("GrpcSettings:ProfileServiceUrl"), new GrpcChannelOptions { HttpHandler = httpHandler });
            client = new ProfileService.ProfileServiceClient(channel);
        }

        public async Task<ObjectResult> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var UserID = Guid.Parse(request.UserID);
                var ChatMessagess = await chatMessageRepository.GetAllMessageOfRoom(UserID);
                var RoomIDs = ChatMessagess.Select(x => x.RoomID).ToList();
                var Rooms = await roomRepository.GetAllRoom(x => RoomIDs.Contains(x.RoomID));
                if (Rooms.Count == 0)
                {
                    return ApiResponse.NotFound("Room Not Found");
                }
                foreach (Room room in Rooms)
                {
                    room.ChatMessages = room.ChatMessages.OrderByDescending(x => x.CreatedAt).ToList();
                }
                Rooms = Rooms.OrderByDescending(x => x.ChatMessages.OrderByDescending(x => x.CreatedAt).ToList()[0].CreatedAt).ToList();
                PaginationResponseHeader header = new PaginationResponseHeader();
                header.TotalCount = Rooms.Count;
                Rooms = Rooms
                    .Skip((request.PaginationRequestHeader.PageNumber - 1) * request.PaginationRequestHeader.PageSize)
                    .Take(request.PaginationRequestHeader.PageSize).ToList();
                
                header.PageIndex = request.PaginationRequestHeader.PageNumber;
                header.PageSize = request.PaginationRequestHeader.PageSize;
                request.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(header));
                var ListOrtherUserID = new List<Guid>();
                foreach (var room in Rooms)
                {
                    ListOrtherUserID.Add(room.ChatMessages.Where(x => x.UserID != UserID).FirstOrDefault().UserID);
                }
                var RoomDtos = mapper.Map<List<RoomDto>>(Rooms);
                GetAllProfileRequest getAllProfileRequest = new GetAllProfileRequest();
                getAllProfileRequest.UserIDs.AddRange(ListOrtherUserID.ConvertAll(g => g.ToString()));
                var response = await client.GetAllProfileAsync(getAllProfileRequest);
                if(response is null)
                {
                    return ApiResponse.NotFound("Room Not Found");
                }
                var profiles = response.Profiles.ToList();
                for (int i = 0; i <= RoomDtos.Count-1; i++)
                {
                    RoomDtos[i].RoomAuthor = new Author();
                    RoomDtos[i].RoomAuthor.UserID = Guid.Parse(profiles[i].UserID);
                    RoomDtos[i].RoomAuthor.FirstName = profiles[i].FirstName;
                    RoomDtos[i].RoomAuthor.LastName = profiles[i].LastName;
                    RoomDtos[i].RoomAuthor.Avatar = profiles[i].Avatar;
                }
                return ApiResponse.OK(RoomDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
