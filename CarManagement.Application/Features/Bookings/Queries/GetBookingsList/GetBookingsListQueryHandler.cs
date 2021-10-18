using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Bookings.Queries.GetBookingsList
{
    public class GetBookingsListQueryHandler : IRequestHandler<GetBookingsListQuery, List<BookingInListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Booking> _bookingRepository;

        public GetBookingsListQueryHandler(IMapper mapper, IAsyncRepository<Booking> bookingRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }
        
        public async Task<List<BookingInListViewModel>> Handle(GetBookingsListQuery request, CancellationToken cancellationToken)
        {
            var all = await _bookingRepository.GetAllAsync();
            //var allOrdered = all.OrderBy(x => x.DateIn);

            return _mapper.Map<List<BookingInListViewModel>>(all);
        }
    }
}