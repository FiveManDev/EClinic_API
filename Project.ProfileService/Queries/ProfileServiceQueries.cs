using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;

namespace Project.ProfileService.Queries
{
    public record GetSimpleProfileQuery(Guid ProfileID) : IRequest<ObjectResult>;
    public record GetProfilesQuery(PaginationRequestHeader PaginationRequestHeader) : IRequest<ObjectResult>;
    public record GetUserProfileQuery(Guid ProfileID) : IRequest<ObjectResult>;

    public record GetDoctorProfileQuery(Guid ProfileID) : IRequest<ObjectResult>;
    public record GetSupporterProfileQuery(Guid ProfileID) : IRequest<ObjectResult>;
    public record GetProfileQuery(Guid ProfileID) : IRequest<ObjectResult>;

}
