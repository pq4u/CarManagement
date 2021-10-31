using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using CarManagement.Application.Contracts.Infrastructure;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Application.Features.Models.Queries.GetModelsExport;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Bookings.Queries.GetBookingsExport
{
    public class GetBookingsExportQueryHandler : IRequestHandler<GetBookingsExportQuery, BookingExportFileVm>
    {
        private readonly IAsyncRepository<Booking> _bookingRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetBookingsExportQueryHandler(IMapper mapper, IAsyncRepository<Booking> bookingRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _csvExporter = csvExporter;
        }

        public async Task<BookingExportFileVm> Handle(GetBookingsExportQuery request, CancellationToken cancellationToken)
        {
            var allBookings = _mapper.Map<List<BookingExportDto>>((await _bookingRepository.GetAllAsync()));

            var fileData = _csvExporter.ExportBookingsToCsv(allBookings);

            var bookingExportFileDto = new BookingExportFileVm() { ContentType = "text/csv", Data = fileData, BookingExportFileName = $"{Guid.NewGuid()}.csv" };

            return bookingExportFileDto;
        }
    }
}