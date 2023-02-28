using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;

namespace Project.ProfileService.Queries
{
    public record GetSimpleProfileQuery(Guid UserID) : IRequest<ObjectResult>;
    public record GetProfilesQuery(PaginationRequestHeader PaginationRequestHeader) : IRequest<ObjectResult>;
    public record GetUserProfilesByIDQuery(Guid UserID) : IRequest<ObjectResult>;
    public record GetDoctorProfileByIDQuery(Guid UserID) : IRequest<ObjectResult>;
    public record GetEmployeeProfileByIDQuery(Guid UserID) : IRequest<ObjectResult>;
    public record GetProfileByIDQuery(Guid UserID) : IRequest<ObjectResult>;
    public record GetAllRelationshipQuery() : IRequest<ObjectResult>;

}
