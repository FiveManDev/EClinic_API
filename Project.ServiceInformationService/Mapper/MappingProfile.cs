using Project.ServiceInformationService.Data;
using Project.ServiceInformationService.Dtos.ServiceDTO;
using Project.ServiceInformationService.Dtos.SpecializationDTO;

namespace Project.ServiceInformationService.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            #region Specialization
            CreateMap<Specialization, SpecializationDTO>()
                .ReverseMap(); 
            
            CreateMap<Specialization, CreateSpecializationDTO>()
                .ReverseMap();

            CreateMap<Specialization, UpdateSpecializationDTO>()
                .ReverseMap();
            #endregion
            #region Service
            //CreateMap<Specialization, SpecializationDTO>()
            //    .ReverseMap();

            CreateMap<Service, CreateServiceDTO>()
                .ReverseMap();

            //CreateMap<Specialization, UpdateSpecializationDTO>()
            //    .ReverseMap();
            #endregion

        }
    }
}
