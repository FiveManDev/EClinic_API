using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Logger;
using Project.ServiceInformationService.Commands;
using Project.ServiceInformationService.Repository.ServicePackageRepository;

namespace Project.ServiceInformationService.Handlers.ServicePackageHandler;

public class IncreaseOrderHandler : IRequestHandler<IncreaseOrderCommand, ObjectResult>
{
    private readonly ILogger<IncreaseOrderHandler> logger;
    private readonly IServicePackageRepository repository;
    private readonly IMapper mapper;

    public IncreaseOrderHandler(ILogger<IncreaseOrderHandler> logger, IServicePackageRepository repository, IMapper mapper)
    {
        this.logger = logger;
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<ObjectResult> Handle(IncreaseOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var servicePackage = await repository.GetAsync(request.servicePackageID);

            if (servicePackage is null)
            {
                return ApiResponse.BadRequest("Service Package not found!");
            }

            servicePackage.TotalOrder++;
            servicePackage.UpdatedAt = DateTime.Now;

            await repository.UpdateAsync(servicePackage);

            return ApiResponse.OK("Update Success.");
        }
        catch (Exception ex)
        {
            logger.WriteLogError(ex.Message);
            return ApiResponse.InternalServerError();
        }

    }
}
