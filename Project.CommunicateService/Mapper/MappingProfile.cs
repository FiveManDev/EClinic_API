using AutoMapper;
using Project.CommunicateService.Data;
using Project.CommunicateService.Dtos.RoomTypeDtos;

namespace Project.CommunicateService.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomType, RoomTypeDto>()
               .ReverseMap();
        }
    }
}
