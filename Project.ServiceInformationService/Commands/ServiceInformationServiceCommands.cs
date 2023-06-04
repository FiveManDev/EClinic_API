using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.ServiceInformationService.Dtos.ServiceDTO;
using Project.ServiceInformationService.Dtos.SpecializationDTO;

namespace Project.ServiceInformationService.Commands
{
    #region Specialization
    public record CreateSpecializationCommand(CreateSpecializationDTO createSpecializationDTO) : IRequest<ObjectResult>;
    public record UpdateSpecializationCommand(UpdateSpecializationDTO updateSpecializationDTO) : IRequest<ObjectResult>;
    public record DeleteSpecializationCommand(DeleteSpecializationDTO deleteSpecializationDTO) : IRequest<ObjectResult>;
    #endregion
    #region Service
    public record CreateServiceCommand(CreateServiceDTO createServiceDTO) : IRequest<ObjectResult>;
    #endregion
}