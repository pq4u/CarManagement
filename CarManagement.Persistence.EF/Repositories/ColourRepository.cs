using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using CarManagement.Persistence.EntityFramework;

namespace CarManagement.Persistence.EF.Repositories
{
    public class ColourRepository : BaseRepository<Colour>, IColourRepository
    {
        public ColourRepository(CarManagementContext dbContext) : base(dbContext)
        {

        }
    }
}