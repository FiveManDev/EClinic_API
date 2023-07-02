using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Data;
using Project.BookingService.Dtos.BookingPackageDTOs;

namespace Project.BookingServiceCommands.Commands
{
    #region BookingPackage
    public record CreateBookingPackageCommand(CreateBookingPackageDTO createBookingPackageDTO) : IRequest<ObjectResult>;
    public record UpdateBookingPackageCommand(UpdateBookingPackageDTO updateBookingPackageDTO) : IRequest<ObjectResult>;
    public record UpdateBookingStatusForBookingPackageCommand(Guid bookingPackageID, BookingStatus bookingStatus) : IRequest<ObjectResult>;
    public record DeleteBookingPackageCommand(Guid bookingPackageID) : IRequest<ObjectResult>;
    #endregion
}