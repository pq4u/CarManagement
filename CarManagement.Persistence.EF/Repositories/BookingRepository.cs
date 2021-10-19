using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using CarManagement.Persistence.EntityFramework;

namespace CarManagement.Persistence.EF.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(CarManagementContext dbContext) : base(dbContext)
        {

        }
    }
}