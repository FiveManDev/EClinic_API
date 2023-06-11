﻿using Grpc.Core;
using Project.Core.Logger;
using Project.ServiceInformationService.Data;
using Project.ServiceInformationService.Protos;
using Project.ServiceInformationService.Repository.SpecializationRepository;

namespace Project.ServiceInformationService.Service
{
    public class DataService : Protos.ServiceInformationService.ServiceInformationServiceBase
    {
        private readonly ISpecializationRepository repository;
        private readonly ILogger<DataService> logger;

        public DataService(ISpecializationRepository repository, ILogger<DataService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public override async Task<GetSpecializations> CheckSpecialization(GetSpecializationRequest request, ServerCallContext context)
        {
            try
            {
                var Specialization = await repository.GetAsync(Guid.Parse(request.SpecializationID));
                if (Specialization == null)
                {
                    return null;
                }
                return new GetSpecializations { SpecializationName = Specialization.SpecializationName, SpecializationID = Specialization.SpecializationID.ToString() };
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return null;
            }
        }

        public override async Task<GetAllSpecializationResponse> GetAllSpecialization(GetAllSpecializationRequest request, ServerCallContext context)
        {
            try
            {
                var SpecializationIds = request.SpecializationIDs.Select(Guid.Parse).ToList();
                var Specializations = await repository.GetAllAsync(x => SpecializationIds.Contains(x.SpecializationID));
                if (Specializations == null)
                {
                    return null;
                }
                var result = new GetAllSpecializationResponse();
                List<GetSpecializations> getSpecializations = new List<GetSpecializations>();
                for (var i = 0; i < SpecializationIds.Count; i++)
                {
                    var sp = Specializations.SingleOrDefault(x => x.SpecializationID == SpecializationIds[i]);
                    getSpecializations.Add(new GetSpecializations
                    {
                        SpecializationID = sp.SpecializationID.ToString(),
                        SpecializationName = sp.SpecializationName
                    });

                }
                result.Specialization.AddRange(getSpecializations);
                return result;
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return null;
            }
        }

        public override async Task<GetSpecializationResponse> GetSpecialization(GetSpecializationRequest request, ServerCallContext context)
        {
            try
            {
                var Specialization = await repository.GetAsync(Guid.Parse(request.SpecializationID));
                if (Specialization == null)
                {
                    return null;
                }
                return new GetSpecializationResponse { SpecializationName = Specialization.SpecializationName };
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return null;
            }
        }
    }
}
