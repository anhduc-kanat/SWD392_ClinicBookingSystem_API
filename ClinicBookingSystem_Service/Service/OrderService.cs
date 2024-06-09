using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;
using ClinicBookingSystem_Service.Models.Request.Order;
using ClinicBookingSystem_Service.Models.Response.Order;

namespace ClinicBookingSystem_Service.Service;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    //get all orders
    public async Task<BaseResponse<IEnumerable<GetOrderResponse>>> GetAllOrders()
    {
        IEnumerable<Order> orders = await _unitOfWork.OrderRepository.GetAllAsync();
        return new BaseResponse<IEnumerable<GetOrderResponse>>("Get all orders successfully", StatusCodeEnum.OK_200,
            _mapper.Map<IEnumerable<GetOrderResponse>>(orders));
    }
    //get order by id
    public async Task<BaseResponse<GetOrderResponse>> GetOrderById(int id)
    {
        Order order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
        return new BaseResponse<GetOrderResponse>("Get order by id successfully", StatusCodeEnum.OK_200,
            _mapper.Map<GetOrderResponse>(order));
    }
    //create order
    public async Task<BaseResponse<CreateOrderResponse>> CreateOrder(CreateOrderRequest request)
    {
        Order order = _mapper.Map<Order>(request);
        await _unitOfWork.OrderRepository.AddAsync(order);
        await _unitOfWork.SaveChangesAsync();
        return new BaseResponse<CreateOrderResponse>("Create order successfully", StatusCodeEnum.Created_201,
            _mapper.Map<CreateOrderResponse>(order));
    }
    //update order
    public async Task<BaseResponse<UpdateOrderResponse>> UpdateOrder(int Id, UpdateOrderRequest request)
    {
        Order order = await _unitOfWork.OrderRepository.GetByIdAsync(Id);
        _mapper.Map(order, request);
        await _unitOfWork.OrderRepository.UpdateAsync(order);
        await _unitOfWork.SaveChangesAsync();
        return new BaseResponse<UpdateOrderResponse>("Update order successfully", StatusCodeEnum.OK_200,
            _mapper.Map<UpdateOrderResponse>(order));
    }
    //delete order
    public async Task<BaseResponse<DeleteOrderResponse>> DeleteOrder(int id)
    {
        Order order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
        await _unitOfWork.OrderRepository.DeleteAsync(order);
        await _unitOfWork.SaveChangesAsync();
        return new BaseResponse<DeleteOrderResponse>("Delete order successfully", StatusCodeEnum.OK_200,
            _mapper.Map<DeleteOrderResponse>(order));
    }
}