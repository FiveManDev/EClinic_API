using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;
using Project.IdentityService.Dtos;

namespace Project.IdentityService.Queries
{
    public record GetAllUserQuery(PaginationRequestHeader PaginationRequestHeader, SearchUserDtos SearchUserDtos, HttpResponse Response) : IRequest<ObjectResult>;
    public record GetAllRoleQuery() : IRequest<ObjectResult>;
}
