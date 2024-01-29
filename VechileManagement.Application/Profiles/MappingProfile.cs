using AutoMapper;
using VechileManagement.Application.Features.Customers.DTOs;
using VechileManagement.Application.Features.Factories.DTOs;
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
            CreateMap<VehicleModel, ListVechileModelsDto>().ReverseMap();

            CreateMap<VehicleModel, UpdateVechileModelDto>().ReverseMap();
            CreateMap<Factory, ListFactoryDto>().ReverseMap();

        }
    }
}
