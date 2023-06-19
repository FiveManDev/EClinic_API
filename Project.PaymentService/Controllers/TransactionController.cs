﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;
using Project.PaymentService.Commands;
using Project.PaymentService.Model;
using Project.PaymentService.Queries;

namespace Project.PaymentService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator mediator;

        public TransactionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetPaymentByID(Guid PaymentID)
        {
            return await mediator.Send(new GetPaymentByIDQuery(PaymentID));
        }
        [HttpGet]
        public async Task<IActionResult> GetRefundByID(Guid RefundID)
        {
            return await mediator.Send(new GetRefundByIDQuery(RefundID));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPaymentTransaction([FromHeader] int PageNumber, [FromHeader] int PageSize)
        {
            PaginationRequestHeader paginationRequestHeader = new PaginationRequestHeader { PageSize = PageSize, PageNumber = PageNumber };
            return await mediator.Send(new GetAllPaymentQuery(paginationRequestHeader, Response));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRefundTransaction([FromHeader] int PageNumber, [FromHeader] int PageSize)
        {
            PaginationRequestHeader paginationRequestHeader = new PaginationRequestHeader { PageSize = PageSize, PageNumber = PageNumber };
            return await mediator.Send(new GetAllRefundQuery(paginationRequestHeader, Response));
        }
        [HttpGet]
        public async Task<IActionResult> GetTransactionQuery(DateTime StartTime, DateTime EndTime, TimeType timeType)
        {
            TransactionQueryModel query = new TransactionQueryModel
            {
                StartTime = StartTime,
                TimeType = timeType,
                EndTime = EndTime
            };
            return await mediator.Send(new GetTransactionQuery(query));
        }
        [HttpPost]
        public async Task<IActionResult> RefundTransaction(RefundModel RefundModel)
        {
            string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            return await mediator.Send(new CreateRefundCommand(RefundModel, ipAddress));
        }
    }
}
