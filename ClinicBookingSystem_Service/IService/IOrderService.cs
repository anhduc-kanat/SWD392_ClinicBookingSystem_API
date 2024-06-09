using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Order;
using ClinicBookingSystem_Service.Models.Response.Order;

namespace ClinicBookingSystem_Service.IService;

public interface IOrderService
{
    Task<BaseResponse<IEnumerable<GetOrderResponse>>> GetAllOrders();
    Task<BaseResponse<GetOrderResponse>> GetOrderById(int id);
    Task<BaseResponse<CreateOrderResponse>> CreateOrder(CreateOrderRequest request);
    Task<BaseResponse<UpdateOrderResponse>> UpdateOrder(int Id, UpdateOrderRequest request);
    Task<BaseResponse<DeleteOrderResponse>> DeleteOrder(int id);
}