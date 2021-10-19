using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using CarManagement.Persistence.EntityFramework;

namespace CarManagement.Persistence.EF.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(CarManagementContext dbContext) : base(dbContext)
        {

        }
    }
}