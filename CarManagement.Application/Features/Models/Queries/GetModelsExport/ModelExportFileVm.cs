using MediatR;

namespace CarManagement.Application.Features.Models.Queries.GetModelsExport
{
    public class ModelExportFileVm
    {
        public string ModelExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}