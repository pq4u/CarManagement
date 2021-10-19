using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using CarManagement.Persistence.EntityFramework;

namespace CarManagement.Persistence.EF.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CarManagementContext dbContext) : base(dbContext)
        {

        }
    }
}