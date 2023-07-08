using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Data;
using Project.Common.Paging;

namespace Project.BookingServiceQueries.Queries
{
    #region Booking Package
    public record GetBookingPackageByIDQuery(Guid BookingPackageID) : IRequest<ObjectResult>;
    public record GetAllBookingPackageForAdQuery(PaginationRequestHeader PaginationRequestHeader, HttpResponse Response,BookingStatus BookingStatus) : IRequest<ObjectResult>;
    public record GetAllBookingPackageForUserQuery(PaginationRequestHeader PaginationRequestHeader, HttpResponse Response, string UserID, BookingStatus BookingStatus) : IRequest<ObjectResult>;
    #endregion

}
