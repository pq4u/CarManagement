using MediatR;

namespace CarManagement.Application.Features.Colours.Queries.GetColoursExport
{
    public class ColourExportFileVm
    {
        public string ColourExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}