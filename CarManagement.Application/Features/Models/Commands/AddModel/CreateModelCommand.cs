using MediatR;

namespace CarManagement.Application.Features.Models.Commands.AddModel
{
    public class CreateModelCommand : IRequest<CreateModelCommandResponse>
    {
        public int ModelId { get; set; }
        
        public string Name { get; set; }
    }
}