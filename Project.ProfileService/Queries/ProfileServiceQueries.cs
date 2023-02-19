using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.ProfileService.Dtos.UserProfile;

namespace Project.ProfileService.Queries
{
    public record GetSimpleProfileQuery(Guid ProfileID) : IRequest<ObjectResult>;
}
