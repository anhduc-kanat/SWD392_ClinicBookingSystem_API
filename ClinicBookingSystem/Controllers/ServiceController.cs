using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Slot;
using ClinicBookingSystem_Service.Models.Response.Slot;
using ClinicBookingSystem_Service;
using Microsoft.AspNetCore.Mvc;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.Response.Service;
using ClinicBookingSystem_Service.Models.Request.Service;

namespace ClinicBookingSystem_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponse<IEnumerable<ServiceResponse>>>> GetServices()
    {
        var services = await _serviceService.GetAllServices();
        return Ok(services);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<ServiceResponse>>> GetService(int id)
    {
        var service = await _serviceService.GetServiceById(id);

        return Ok(service);
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<ServiceResponse>>> AddService([FromBody] CreateServiceRequest request)
    {
        var createdService = await _serviceService.CreateService(request);
        return createdService;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BaseResponse<ServiceResponse>>> UpdateService(int id, [FromBody] UpdateServiceRequest request)
    {
        return await _serviceService.UpdateService(id, request);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponse<ServiceResponse>>> DeleteService(int id)
    {
        return await _serviceService.DeleteService(id);
    }
}