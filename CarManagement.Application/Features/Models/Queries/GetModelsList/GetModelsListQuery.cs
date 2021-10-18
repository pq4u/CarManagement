using System.Collections.Generic;
using MediatR;

namespace CarManagement.Application.Features.Models.Queries.GetModelsList
{
    public class GetModelsListQuery : IRequest<List<CarModelInListViewModel>>
    {
        
    }
}