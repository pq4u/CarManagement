using MediatR;

namespace CarManagement.Application.Features.Bookings.Queries.GetBookingsExport
{
    public class BookingExportFileVm
    {
        public string BookingExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}