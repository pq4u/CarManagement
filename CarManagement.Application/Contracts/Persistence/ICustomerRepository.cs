using CarManagement.Domain.Entities;

namespace CarManagement.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        
    }
}