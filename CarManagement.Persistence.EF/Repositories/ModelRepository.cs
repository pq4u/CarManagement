using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using CarManagement.Persistence.EntityFramework;

namespace CarManagement.Persistence.EF.Repositories
{
    public class ModelRepository : BaseRepository<Model>, IModelRepository
    {
        public ModelRepository(CarManagementContext dbContext) : base(dbContext)
        {

        }
    }
}