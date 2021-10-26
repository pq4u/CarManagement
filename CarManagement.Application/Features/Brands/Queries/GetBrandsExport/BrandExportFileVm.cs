using MediatR;

namespace CarManagement.Application.Features.Brands.Queries.GetBrandsExport
{
    public class BrandExportFileVm
    {
        public string BrandExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}