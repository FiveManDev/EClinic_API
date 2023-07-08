using AutoMapper;
using Project.BookingService.Data;
using Project.BookingService.Dtos.BookingPackageDTOs;

namespace Project.BookingService.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region BookingPackage
            CreateMap<BookingPackage, BookingPackageDTO>()
                .ForMember(
                    des => des.BookingStatus,
                    opt => opt.MapFrom(src => src.BookingStatus.ToString())
                )
                .ReverseMap();

            CreateMap<BookingPackage, CreateBookingPackageDTO>()
                .ReverseMap();
            #endregion

        }
    }
}
