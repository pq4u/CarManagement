using CarManagement.Application.Features.Vehicles.Queries.GetVehiclesList;
using MediatR;

namespace CarManagement.Application.Features.Vehicles.Queries.GetVehicleDetail
{
    public class GetVehicleDetailQuery : IRequest<VehicleInListViewModel>, IRequest<VehicleDetailViewModel>
    {
        public int Id { get; set; }
    }
}