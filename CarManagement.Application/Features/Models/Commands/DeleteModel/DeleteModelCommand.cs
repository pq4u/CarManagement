using MediatR;

namespace CarManagement.Application.Features.Models.Commands.DeleteModel
{
    public class DeleteModelCommand : IRequest
    {
        public int ModelId { get; set; }
    }
}