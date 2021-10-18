using System;
using CarManagement.Application.Features.Bookings.Queries.GetBookingsList;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Bookings.Queries.GetBookingDetail
{
    public class GetBookingDetailQuery : IRequest<BookingInListViewModel>, IRequest<BookingDetailViewModel>
    {
        public int Id { get; set; }
    }
}