using AutoMapper;
using CarManagement.Application.Features.Bookings.Commands.CreateBooking;
using CarManagement.Domain.Entities;

namespace CarManagement.Application.Mapping.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, CreateBookingCommand>().ReverseMap();
        }
    }
}