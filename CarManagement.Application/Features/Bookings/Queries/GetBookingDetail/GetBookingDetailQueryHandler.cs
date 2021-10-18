using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Application.Features.Bookings.Queries.GetBookingDetail.Dtos;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Bookings.Queries.GetBookingDetail
{
    public class GetBrandDetailQueryHandler : IRequestHandler<GetBookingDetailQuery, BookingDetailViewModel>
    {
        private readonly IAsyncRepository<Booking> _bookingRepository;
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IAsyncRepository<Vehicle> _vehicleRepository;
        private readonly IMapper _mapper;

        public GetBrandDetailQueryHandler(IAsyncRepository<Booking> bookingRepository, IAsyncRepository<Customer> customerRepository, IAsyncRepository<Vehicle> vehicleRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _customerRepository = customerRepository;
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<BookingDetailViewModel> Handle(GetBookingDetailQuery request,
            CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(request.Id);
            var bookingDetail = _mapper.Map<BookingDetailViewModel>(booking);
            var customer = await _customerRepository.GetByIdAsync(booking.CustomerId);
            var vehicle = await _vehicleRepository.GetByIdAsync(booking.VehicleId);

            bookingDetail.Customer = _mapper.Map<CustomerDto>(customer);
            bookingDetail.Vehicle = _mapper.Map<VehicleDto>(vehicle);

            return bookingDetail;
        }
    }
}