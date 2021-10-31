using MediatR;

namespace CarManagement.Application.Features.Customers.Queries.GetCustomersExport
{
    public class CustomerExportFileVm
    {
        public string CustomerExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}