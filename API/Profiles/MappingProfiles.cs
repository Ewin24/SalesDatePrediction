using API.Dtos.Employee;
using API.Dtos.Order;
using API.Dtos.Product;
using API.Dtos.Shipper;
using AutoMapper;
using Domain.Entities;
using Dominio;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ShipperDto, Shipper>().ReverseMap();
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<CreateOrderDto, CreateOrder>().ReverseMap();
        }
    }
}