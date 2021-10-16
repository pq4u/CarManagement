using MediatR;

namespace CarManagement.Application.Features.Models.Commands.EditModel
{
    public class UpdateModelCommand : IRequest
    {
        public int ModelId { get; set; }
        
        public string Name { get; set; }
    }
}