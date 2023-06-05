using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;
using Project.PaymentService.Model;

namespace Project.PaymentService.Queries
{
    public record GetPaymentURLQuery(Data.PaymentService PaymentService, Guid BookingID, string IpAddress = null) : IRequest<ObjectResult>;
    public record GetAllPaymentQuery(PaginationRequestHeader PaginationRequestHeader, HttpResponse Response) : IRequest<ObjectResult>;
    public record GetAllRefundQuery(PaginationRequestHeader PaginationRequestHeader, HttpResponse Response) : IRequest<ObjectResult>;
    public record GetTransactionQuery(TransactionQueryModel TransactionQueryModel) : IRequest<ObjectResult>;
}
