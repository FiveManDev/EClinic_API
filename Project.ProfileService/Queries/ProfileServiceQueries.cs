using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;

namespace Project.ProfileService.Queries
{
    public record GetSimpleProfileQuery(Guid UserID) : IRequest<ObjectResult>;
    public record GetUserProfilesByIDQuery(Guid UserID) : IRequest<ObjectResult>;
    public record GetUserMainProfilesByIDQuery(string UserID) : IRequest<ObjectResult>;
    public record GetDoctorProfileByIDQuery(Guid UserID) : IRequest<ObjectResult>;
    public record GetEmployeeProfileByIDQuery(Guid UserID) : IRequest<ObjectResult>;
    public record GetProfileByIDQuery(Guid UserID) : IRequest<ObjectResult>;
    public record GetAllRelationshipQuery() : IRequest<ObjectResult>;
    public record GetUserProfileQuery(PaginationRequestHeader PaginationRequestHeader, string SearchText, HttpResponse Response) : IRequest<ObjectResult>;
    public record GetDoctorProfileQuery(PaginationRequestHeader PaginationRequestHeader, string SearchText, HttpResponse Response) : IRequest<ObjectResult>;
    public record GetEmployeeProfileQuery(PaginationRequestHeader PaginationRequestHeader, string SearchText, HttpResponse Response,string Role) : IRequest<ObjectResult>;
    public record GetBloodTypesQuery() : IRequest<ObjectResult>;

}
