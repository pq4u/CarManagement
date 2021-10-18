using System.Collections.Generic;
using MediatR;

namespace CarManagement.Application.Features.Colours.Queries.GetColoursList
{
    public class GetColoursListQuery : IRequest<List<ColourInListViewModel>>
    {
        
    }
}