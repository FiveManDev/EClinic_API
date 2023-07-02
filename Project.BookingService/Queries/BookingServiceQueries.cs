using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Paging;

namespace Project.BookingServiceQueries.Queries
{
    #region Booking Package
    public record GetBookingPackageByIDQuery(Guid bookingPackageID) : IRequest<ObjectResult>;
    public record GetAllBookingPackageForAdQuery(PaginationRequestHeader PaginationRequestHeader, HttpResponse Response) : IRequest<ObjectResult>;
    #endregion

}
