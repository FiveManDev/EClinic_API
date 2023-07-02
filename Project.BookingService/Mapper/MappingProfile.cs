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
                .ReverseMap();

            CreateMap<BookingPackage, CreateBookingPackageDTO>()
                .ReverseMap();

            CreateMap<BookingPackage, UpdateBookingPackageDTO>()
                .ReverseMap();
            #endregion

        }
    }
}
