using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.Order;
using ClinicBookingSystem_Service.Models.Response.Order;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingOrder : Profile
{
    public MappingOrder()
    {
        CreateMap<Order, CreateOrderRequest>();
        CreateMap<Order, UpdateOrderRequest>();
        CreateMap<Order, CreateOrderResponse>().ReverseMap();
        CreateMap<Order, UpdateOrderResponse>().ReverseMap();
        CreateMap<Order, DeleteOrderResponse>().ReverseMap();
        CreateMap<Order, GetOrderResponse>().ReverseMap();
    }
}