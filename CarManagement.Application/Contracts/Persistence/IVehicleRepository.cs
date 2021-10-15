using CarManagement.Domain.Entities;

namespace CarManagement.Application.Contracts.Persistence
{
    public interface IVehicleRepository : IAsyncRepository<Vehicle>
    {
        
    }
}