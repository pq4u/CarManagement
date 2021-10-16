using CarManagement.Application.Features.Bookings.Commands.CreateBooking;
using MediatR;

namespace CarManagement.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<CreateBrandCommandResponse>
    {

        public int BrandId { get; set; }

        public string Name { get; set; }
    }
}