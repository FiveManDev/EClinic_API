using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Logger;
using Project.PaymentService.Model;
using Project.PaymentService.Queries;
using Project.PaymentService.Repository.PaymentRepositories;

namespace Project.RefundService.Handlers.RefundHandlers
{
    public class GetPaymentByIDHandler : IRequestHandler<GetPaymentByIDQuery, ObjectResult>
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly ILogger<GetPaymentByIDHandler> logger;
        private readonly IMapper mapper;

        public GetPaymentByIDHandler(IPaymentRepository paymentRepository, ILogger<GetPaymentByIDHandler> logger, IMapper mapper)
        {
            this.paymentRepository = paymentRepository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<ObjectResult> Handle(GetPaymentByIDQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var Payment = await paymentRepository.GetPayment(request.PaymentID);
                var paymentDtos = mapper.Map<PaymentDetailDtos>(Payment);
                return ApiResponse.OK(paymentDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
