using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Salary;
using ClinicBookingSystem_Service.Models.Request.Specification;
using ClinicBookingSystem_Service.Models.Response.Salary;
using ClinicBookingSystem_Service.Models.Response.Specification;
using ClinicBookingSystem_Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecificationController : ControllerBase
{
    private readonly ISpecificationService _specificationService;

    public SpecificationController(ISpecificationService specificationService)
    {
        _specificationService = specificationService;
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponse<IEnumerable<SpecificationResponse>>>> GetSpecifications()
    {
        var specifications = await _specificationService.GetAllSpecifications();
        return Ok(specifications);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<SpecificationResponse>>> GetSalary(int id)
    {
        var specification = await _specificationService.GetSpecificationById(id);
        return Ok(specification);
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<SpecificationResponse>>> AddSpecification([FromBody] CreateSpecificationRequest request)
    {
        var createdSpecification = await _specificationService.CreateSpecification(request);
        return createdSpecification;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BaseResponse<SpecificationResponse>>> UpdateSpecification(int id, [FromBody] UpdateSpecificationRequest request)
    {
        return await _specificationService.UpdateSpecification(id, request);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponse<SpecificationResponse>>> DeleteSpecification(int id)
    {
        return await _specificationService.DeleteSpecification(id);
    }
}