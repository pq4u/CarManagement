using System.Collections.Generic;
using MediatR;

namespace CarManagement.Application.Features.Bookings.Queries.GetBookingsList
{
    public class GetBookingsListQuery : IRequest<List<BookingInListViewModel>>
    {
        
    }
}