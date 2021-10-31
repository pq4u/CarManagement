using AutoMapper;
using CarManagement.Application.Features.Bookings.Commands.CreateBooking;
using CarManagement.Application.Features.Bookings.Commands.UpdateBooking;
using CarManagement.Application.Features.Bookings.Queries.GetBookingDetail;
using CarManagement.Application.Features.Bookings.Queries.GetBookingsList;
using CarManagement.Application.Features.Brands.Commands.CreateBrand;
using CarManagement.Application.Features.Brands.Commands.EditBrand;
using CarManagement.Application.Features.Brands.Queries.GetBrandDetail;
using CarManagement.Application.Features.Brands.Queries.GetBrandsExport;
using CarManagement.Application.Features.Brands.Queries.GetBrandsList;
using CarManagement.Application.Features.Colours.Commands.AddColour;
using CarManagement.Application.Features.Colours.Commands.EditColour;
using CarManagement.Application.Features.Colours.Queries.GetColourDetail;
using CarManagement.Application.Features.Colours.Queries.GetColoursExport;
using CarManagement.Application.Features.Colours.Queries.GetColoursList;
using CarManagement.Application.Features.Customers.Commands.AddCustomer;
using CarManagement.Application.Features.Customers.Commands.EditCustomer;
using CarManagement.Application.Features.Customers.Queries.GetCustomerDetail;
using CarManagement.Application.Features.Customers.Queries.GetCustomersExport;
using CarManagement.Application.Features.Customers.Queries.GetCustomersList;
using CarManagement.Application.Features.Models.Commands.AddModel;
using CarManagement.Application.Features.Models.Commands.EditModel;
using CarManagement.Application.Features.Models.Queries.GetModelDetail;
using CarManagement.Application.Features.Models.Queries.GetModelsExport;
using CarManagement.Application.Features.Models.Queries.GetModelsList;
using CarManagement.Application.Features.Vehicles.Commands.AddVehicle;
using CarManagement.Application.Features.Vehicles.Commands.EditVehicle;
using CarManagement.Application.Features.Vehicles.Queries.GetVehicleDetail;
using CarManagement.Application.Features.Vehicles.Queries.GetVehiclesExport;
using CarManagement.Application.Features.Vehicles.Queries.GetVehiclesList;
using CarManagement.Domain.Entities;

namespace CarManagement.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingInListViewModel>()
                .ReverseMap();
            CreateMap<Booking, BookingDetailViewModel>();
            CreateMap<Booking, CreateBookingCommand>().ReverseMap();
            CreateMap<Booking, UpdateBookingCommand>().ReverseMap();
            CreateMap<Booking, BookingExportDto>();

            CreateMap<Brand, BrandInListViewModel>()
                .ReverseMap();
            CreateMap<Brand, BrandDetailViewModel>();
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
            CreateMap<Brand, BrandExportDto>();
            
            CreateMap<Colour, ColourInListViewModel>()
                .ReverseMap();
            CreateMap<Colour, ColourDetailViewModel>();
            CreateMap<Colour, CreateColourCommand>().ReverseMap();
            CreateMap<Colour, UpdateColourCommand>().ReverseMap();
            CreateMap<Colour, ColourExportDto>();
            
            CreateMap<Customer, CustomerInListViewModel>()
                .ReverseMap();
            CreateMap<Customer, CustomerDetailViewModel>();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CustomerExportDto>();
            
            CreateMap<Model, CarModelInListViewModel>()
                .ReverseMap();
            CreateMap<Model, CarModelDetailViewModel>();
            CreateMap<Model, CreateModelCommand>().ReverseMap();
            CreateMap<Model, UpdateModelCommand>().ReverseMap();
            CreateMap<Model, ModelExportDto>();
            
            CreateMap<Vehicle, VehicleInListViewModel>()
                .ReverseMap();
            CreateMap<Vehicle, VehicleDetailViewModel>();
            CreateMap<Vehicle, CreateVehicleCommand>().ReverseMap();
            CreateMap<Vehicle, UpdateVehicleCommand>().ReverseMap();
            CreateMap<Vehicle, VehicleExportDto>();
        }
    }
}