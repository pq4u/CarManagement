using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Models.Queries.GetModelsList
{
    public class GetModelsListQueryHandler : IRequestHandler<GetModelsListQuery, List<CarModelInListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Model> _modelRepository;

        public GetModelsListQueryHandler(IMapper mapper, IAsyncRepository<Model> modelRepository)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;
        }
        
        public async Task<List<CarModelInListViewModel>> Handle(GetModelsListQuery request, CancellationToken cancellationToken)
        {
            var all = await _modelRepository.GetAllAsync();

            return _mapper.Map<List<CarModelInListViewModel>>(all);
        }
    }
}