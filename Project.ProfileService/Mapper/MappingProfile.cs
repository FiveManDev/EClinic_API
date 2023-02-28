using Project.ProfileService.Data;
using Project.ProfileService.Dtos.DoctorProfile;
using Project.ProfileService.Dtos.EmployeeProfile;
using Project.ProfileService.Dtos.Profile;
using Project.ProfileService.Dtos.Relationship;
using Project.ProfileService.Dtos.UserProfile;

namespace Project.ProfileService.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Profile, UserProfileDtos>()
                .ForMember(
                    des => des.BloodType,
                    opt => opt.MapFrom(src => src.HealthProfile.BloodType)
                )
                .ForMember(
                    des => des.Height,
                    opt => opt.MapFrom(src => src.HealthProfile.Height)
                )
                .ForMember(
                    des => des.Weight,
                    opt => opt.MapFrom(src => src.HealthProfile.Weight)
                )
                .ForMember(
                    des => des.RelationshipID,
                    opt => opt.MapFrom(src => src.HealthProfile.RelationshipID)
                )
                .ForMember(
                    des => des.RelationshipName,
                    opt => opt.MapFrom(src => src.HealthProfile.Relationship.RelationshipName)
                )
                .ReverseMap();
            CreateMap<Profile, DoctorProfileDtos>()
                .ForMember(
                    des => des.Title,
                    opt => opt.MapFrom(src => src.DoctorProfile.Title)
                )
                .ForMember(
                    des => des.Description,
                    opt => opt.MapFrom(src => src.DoctorProfile.Description)
                )
                .ForMember(
                    des => des.WorkStart,
                    opt => opt.MapFrom(src => src.DoctorProfile.WorkStart)
                )
                .ForMember(
                    des => des.SpecializationID,
                    opt => opt.MapFrom(src => src.DoctorProfile.SpecializationID)
                )
                .ForMember(
                    des => des.Quality,
                    opt => opt.MapFrom(src => src.DoctorProfile.Quality)
                )
                .ReverseMap();
            CreateMap<Profile, EmployeeProfileDtos>()
                .ForMember(
                    des => des.Description,
                    opt => opt.MapFrom(src => src.DoctorProfile.Description)
                )
                .ForMember(
                    des => des.WorkStart,
                    opt => opt.MapFrom(src => src.DoctorProfile.WorkStart)
                )
                .ForMember(
                    des => des.Description,
                    opt => opt.MapFrom(src => src.DoctorProfile.Description)
                )
                .ReverseMap();
            CreateMap<Profile, SimpleProfileDtos>()
                .ForMember(
                    des => des.AvatarKey,
                    opt => opt.MapFrom(src => src.Avatar)
                )
               .ReverseMap();
            CreateMap<Profile, GetUserProfileDtos>()
               .ReverseMap();
            CreateMap<Profile, GetDoctorProfileDtos>()
                .ForMember(
                    des => des.Title,
                    opt => opt.MapFrom(src => src.DoctorProfile.Title)
                )
                 .ForMember(
                    des => des.WorkStart,
                    opt => opt.MapFrom(src => src.DoctorProfile.WorkStart)
                )
               .ReverseMap();
            CreateMap<Profile, GetEmployeeProfileDtos>()
                .ForMember(
                   des => des.WorkStart,
                   opt => opt.MapFrom(src => src.DoctorProfile.WorkStart)
               )
              .ReverseMap();
            CreateMap<Profile, ProfileDtos>()
             .ReverseMap();
            CreateMap<Relationship, RelationshipDtos>()
             .ReverseMap();
        }
    }
}
