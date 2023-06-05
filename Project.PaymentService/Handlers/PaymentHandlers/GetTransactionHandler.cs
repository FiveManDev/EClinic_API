using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Logger;
using Project.PaymentService.Commands;
using Project.PaymentService.Data;
using Project.PaymentService.Model;
using Project.PaymentService.MomoPayment;
using Project.PaymentService.Queries;
using Project.PaymentService.Repository.PaymentRepositories;
using Project.PaymentService.VNPayPayment;

namespace Project.PaymentService.Handlers.PaymentHandlers
{
    public class GetTransactionHandler : IRequestHandler<GetTransactionQuery, ObjectResult>
    {
        private readonly ILogger<GetTransactionHandler> logger;
        private readonly IPaymentRepository paymentRepository;

        public GetTransactionHandler(ILogger<GetTransactionHandler> logger, IPaymentRepository paymentRepository)
        {
            this.logger = logger;
            this.paymentRepository = paymentRepository;
        }

        public async Task<ObjectResult> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                await Task.CompletedTask;
                return ApiResponse.InternalServerError();
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
