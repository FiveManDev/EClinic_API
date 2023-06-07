﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Common.Paging;
using Project.Common.Response;
using Project.Core.Logger;
using Project.ServiceInformationService.Dtos.ServicePackageDTOs;
using Project.ServiceInformationService.Queries;
using Project.ServiceInformationService.Repository.ServicePackageRepository;

namespace Project.ServiceInformationService.Handlers.ServicePackageHandler;

public class GetAllServicePackageHandler : IRequestHandler<GetAllServicePackageQuery, ObjectResult>
{
    private readonly IServicePackageRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetAllServicePackageHandler> logger;

    public GetAllServicePackageHandler(IServicePackageRepository repository, IMapper mapper, ILogger<GetAllServicePackageHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ObjectResult> Handle(GetAllServicePackageQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var servicePackages = await repository.GetAllServicePackageAsync(x => x.IsActive);
            if (servicePackages == null)
            {
                return ApiResponse.NotFound("Service Package Not Found.");
            }
            PaginationResponseHeader header = new PaginationResponseHeader();
            header.TotalCount = servicePackages.Count;
            servicePackages = servicePackages
                .OrderByDescending(x => x.ServicePackageName)
                .Skip((request.PaginationRequestHeader.PageNumber - 1) * request.PaginationRequestHeader.PageSize)
                .Take(request.PaginationRequestHeader.PageSize).ToList();

            header.PageIndex = request.PaginationRequestHeader.PageNumber;
            header.PageSize = request.PaginationRequestHeader.PageSize;

            request.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(header));
            List<ServicePackageDTO> servicePackageDTOs = mapper.Map<List<ServicePackageDTO>>(servicePackages);
            return ApiResponse.OK<List<ServicePackageDTO>>(servicePackageDTOs);
        }
        catch (Exception ex)
        {
            logger.WriteLogError(ex.Message);
            return ApiResponse.InternalServerError();
        }
    }
}
