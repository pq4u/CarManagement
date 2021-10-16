using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Application.Features.Models.Commands.AddModel;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Models.Commands.DeleteModel
{
    public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public DeleteModelCommandHandler(IMapper mapper, IModelRepository modelRepository)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;
        }

        public async Task<Unit> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            var model = await _modelRepository.GetByIdAsync(request.ModelId);
            await _modelRepository.DeleteAsync(model);
            
            return Unit.Value;
        }
    }
}