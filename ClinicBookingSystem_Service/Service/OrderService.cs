using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
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
        var orders = await _unitOfWork.OrderRepository.GetAllAsync();
        return _mapper.Map<BaseResponse<IEnumerable<GetOrderResponse>>>(orders);
    }
    //get order by id
    public async Task<BaseResponse<GetOrderResponse>> GetOrderById(int id)
    {
        var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
        return _mapper.Map<BaseResponse<GetOrderResponse>>(order);
    }
    //create order
    public async Task<BaseResponse<CreateOrderResponse>> CreateOrder(CreateOrderRequest request)
    {
        var order = _mapper.Map<Order>(request);
        await _unitOfWork.OrderRepository.AddAsync(order);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaseResponse<CreateOrderResponse>>(order);
    }
    //update order
    public async Task<BaseResponse<UpdateOrderResponse>> UpdateOrder(int Id, UpdateOrderRequest request)
    {
        var order = await _unitOfWork.OrderRepository.GetByIdAsync(Id);
        _mapper.Map(order, request);
        await _unitOfWork.OrderRepository.UpdateAsync(order);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaseResponse<UpdateOrderResponse>>(order);
    }
    //delete order
    public async Task<BaseResponse<DeleteOrderResponse>> DeleteOrder(int id)
    {
        var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
        await _unitOfWork.OrderRepository.DeleteAsync(order);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaseResponse<DeleteOrderResponse>>(order);
    }
}