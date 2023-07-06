using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.NotificationService.Dtos;

namespace Project.NotificationService.Commands
{
    public record VerifyEmailCommand(string email) : IRequest<ObjectResult>;
    public record ConfirmEmailCommand(string email) : IRequest<ObjectResult>;
    public record SendBillCommand(string email,PaymentModel PaymentModel) : IRequest<ObjectResult>;
}
