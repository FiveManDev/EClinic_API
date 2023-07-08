using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Data;
using Project.BookingService.Dtos.BookingPackageDTOs;

namespace Project.BookingServiceCommands.Commands
{
    #region BookingPackage
    public record CreateBookingPackageCommand(CreateBookingPackageDTO CreateBookingPackageDTO) : IRequest<BookingPackage>;
    public record UpdateBookingStatusForBookingPackageCommand(Guid BookingPackageID, BookingStatus BookingStatus) : IRequest<ObjectResult>;
    #endregion
    #region BookingDoctor
    public record CreateBookingDoctorCommand(CreateBookingPackageDTO createBookingPackageDTO) : IRequest<BookingDoctor>;
    public record UpdateBookingStatusForBookingDoctorCommand(Guid BookingPackageID, BookingStatus BookingStatus) : IRequest<ObjectResult>;
    #endregion
}