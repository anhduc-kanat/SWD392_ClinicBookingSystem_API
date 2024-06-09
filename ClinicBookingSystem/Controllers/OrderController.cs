using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Order;
using ClinicBookingSystem_Service.Models.Response.Order;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    // GET: api/order
    [HttpGet]
    [Route("get-all-orders")]
    public async Task<ActionResult<BaseResponse<GetOrderResponse>>> GetAllOrders()
    {
        var response = await _orderService.GetAllOrders();
        return Ok(response);
    }
    // GET: api/order/1
    [HttpGet]
    [Route("get-order-by-id/{id}")]
    public async Task<ActionResult<BaseResponse<GetOrderResponse>>> GetOrderById(int id)
    {
        var response = await _orderService.GetOrderById(id);
        return Ok(response);
    }
    // POST: api/order
    [HttpPost]
    [Route("create-order")]
    public async Task<ActionResult<BaseResponse<CreateOrderResponse>>> CreateOrder(CreateOrderRequest request)
    {
        var response = await _orderService.CreateOrder(request);
        return Ok(response);
    }
    // PUT: api/order/1
    [HttpPut]
    [Route("update-order/{id}")]
    public async Task<ActionResult<BaseResponse<UpdateOrderResponse>>> UpdateOrder(int id, UpdateOrderRequest request)
    {
        var response = await _orderService.UpdateOrder(id, request);
        return Ok(response);
    }
    // DELETE: api/order/1
    [HttpDelete]
    [Route("delete-order/{id}")]
    public async Task<ActionResult<BaseResponse<DeleteOrderResponse>>> DeleteOrder(int id)
    {
        var response = await _orderService.DeleteOrder(id);
        return Ok(response);
    }
}