using System.Collections.Generic;
using MediatR;

namespace CarManagement.Application.Features.Vehicles.Queries.GetVehiclesList
{
    public class GetVehiclesListQuery : IRequest<List<VehicleInListViewModel>>
    {
        
    }
}