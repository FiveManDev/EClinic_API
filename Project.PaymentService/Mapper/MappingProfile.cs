using AutoMapper;
using Project.PaymentService.Data;
using Project.PaymentService.Model;

namespace Project.PaymentService.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Payment, PaymentDtos>()
                .ForPath(
                    des => des.IsRefund,
                    opt => opt.MapFrom(src => src.Refund == null ? false : true)
                )
                .ReverseMap();
            CreateMap<Refund, RefundDtos>()
                .ReverseMap();
        }
    }
}
