using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Models.Commands.EditModel
{
    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Model>(request);

            await _modelRepository.UpdateAsync(model);
            return Unit.Value;
        }
    }
}