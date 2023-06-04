using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;
using Project.ServiceInformationService.Dtos.SpecializationDTO;

namespace Project.ServiceInformationService.Queries
{
    #region Specialization
    public record GetAllSpecializationQuery(PaginationRequestHeader PaginationRequestHeader, HttpResponse Response) : IRequest<ObjectResult>;
    public record SearchSpecializationQuery(PaginationRequestHeader PaginationRequestHeader, SearchSpecializationDTO searchSpecializationDTO, HttpResponse Response) : IRequest<ObjectResult>;
    #endregion
    #region Service
    public record GetAllServiceQuery(PaginationRequestHeader PaginationRequestHeader, HttpResponse Response) : IRequest<ObjectResult>;
    public record GetAllServiceForAdQuery(PaginationRequestHeader PaginationRequestHeader, HttpResponse Response) : IRequest<ObjectResult>;
    //public record SearchSpecializationQuery(PaginationRequestHeader PaginationRequestHeader, SearchSpecializationDTO searchSpecializationDTO, HttpResponse Response) : IRequest<ObjectResult>;
    #endregion
}
