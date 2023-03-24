using AutoMapper;
using Project.CommunicateService.Data;
using Project.CommunicateService.Dtos.ChatMessageDtos;
using Project.CommunicateService.Dtos.RoomTypeDtos;
using Project.CommunicateService.Dtos.VideoCallDtos;

namespace Project.CommunicateService.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomType, RoomTypeDto>()
               .ReverseMap();
            CreateMap<ChatMessage, ChatMessageDtos>()
               .ReverseMap();
            CreateMap<VideoCall, VideoCallDtos>()
               .ReverseMap();
        }
    }
}
