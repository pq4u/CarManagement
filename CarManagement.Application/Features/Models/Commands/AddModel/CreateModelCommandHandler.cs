using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Models.Commands.AddModel
{
    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreateModelCommandResponse>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public CreateModelCommandHandler(IMapper mapper, IModelRepository modelRepository)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;
        }

        public async Task<CreateModelCommandResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateModelCommandValidator(_modelRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreateModelCommandResponse(validatorResult);

            var model = _mapper.Map<Model>(request);
            model = await _modelRepository.AddAsync(model);

            return new CreateModelCommandResponse(model.ModelId);
        }
    }
}