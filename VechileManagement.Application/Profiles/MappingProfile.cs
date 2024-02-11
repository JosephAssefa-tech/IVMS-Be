using AutoMapper;
using VechileManagement.Application.Features.Countries.DTOs;
using VechileManagement.Application.Features.Customers.DTOs;
using VechileManagement.Application.Features.Depreciations.DTOs;
using VechileManagement.Application.Features.Factories.DTOs;
using VechileManagement.Application.Features.Inflations.DTOs;
using VechileManagement.Application.Features.Orders.DTOs;
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Domain.Entities;

namespace VechileManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, ListCustomerDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDTO>().ReverseMap();
            CreateMap<Order, ListOrderDTO>().ReverseMap();
            CreateMap<Order, CreateOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();

            CreateMap<VehicleModel, CreateVechileModelDto>().ReverseMap();
            CreateMap<VehicleModel, ListGetCountriesDto>().ReverseMap();

            CreateMap<VehicleModel, UpdateVechileModelDto>().ReverseMap();
            CreateMap<Factory, ListFactoryDto>().ReverseMap();
            CreateMap<VehicleModel, VechileModelDto>().ReverseMap();
            CreateMap<Factory, FactoryDto>().ReverseMap();
            CreateMap<Factory, CreateFactoryDto>().ReverseMap();
            CreateMap<Factory, ListFactoryDto>().ReverseMap();
            CreateMap<Factory, UpdateFactoryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, ListCountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Inflation, InflationDto>().ReverseMap();
            CreateMap<Inflation, CreateInflationDto>().ReverseMap();
            CreateMap<Inflation, ListInflationDto>().ReverseMap();
            CreateMap<Inflation, UpdateInflationDto>().ReverseMap();


            CreateMap<Depreciation, CreateDeperciationDto>().ReverseMap();
            CreateMap<Depreciation, DeperciationDto>().ReverseMap();
            CreateMap<Depreciation, ListDeperciationDto>().ReverseMap();
            CreateMap<Depreciation, UpdateDeperciationDto>().ReverseMap();
        }
    }
}
