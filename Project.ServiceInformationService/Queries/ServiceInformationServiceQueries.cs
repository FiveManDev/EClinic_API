using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;
using Project.ServiceInformationService.Dtos.ServiceDTOs;
using Project.ServiceInformationService.Dtos.SpecializationDTOs;

namespace Project.ServiceInformationService.Queries
{
    #region Specialization
    public record GetSpecializationByIDQuery(Guid specializationID) : IRequest<ObjectResult>;
    public record GetAllSpecializationQuery(PaginationRequestHeader PaginationRequestHeader, HttpResponse Response) : IRequest<ObjectResult>;
    public record SearchSpecializationQuery(PaginationRequestHeader PaginationRequestHeader, SearchSpecializationDTO searchSpecializationDTO, HttpResponse Response) : IRequest<ObjectResult>;
    #endregion
    #region Service
    public record GetServiceByIDQuery(Guid serviceID) : IRequest<ObjectResult>;
    public record GetServiceByIDForAdQuery(Guid serviceID) : IRequest<ObjectResult>;
    public record GetAllServiceQuery(PaginationRequestHeader PaginationRequestHeader, HttpResponse Response) : IRequest<ObjectResult>;
    public record GetAllServiceForAdQuery(PaginationRequestHeader PaginationRequestHeader, HttpResponse Response) : IRequest<ObjectResult>;
    public record SearchServiceQuery(PaginationRequestHeader PaginationRequestHeader, SearchServiceDTO searchServiceDTO, HttpResponse Response) : IRequest<ObjectResult>;
    public record SearchServiceForAdQuery(PaginationRequestHeader PaginationRequestHeader, SearchServiceDTO searchServiceDTO, HttpResponse Response) : IRequest<ObjectResult>;
    #endregion
}
