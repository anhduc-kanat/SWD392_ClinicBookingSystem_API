using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Salary;
using ClinicBookingSystem_Service.Models.Request.Service;
using ClinicBookingSystem_Service.Models.Response.Salary;
using ClinicBookingSystem_Service.Models.Response.Service;
using ClinicBookingSystem_Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalaryController : ControllerBase
{
    private readonly ISalaryService _salaryService;

    public SalaryController(ISalaryService salaryService)
    {
        _salaryService = salaryService;
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponse<IEnumerable<SalaryResponse>>>> GetSalaries()
    {
        var salaries = await _salaryService.GetAllSalaries();
        return Ok(salaries);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<SalaryResponse>>> GetSalary(int id)
    {
        var salary = await _salaryService.GetSalaryById(id);

        return Ok(salary);
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<SalaryResponse>>> AddSalary([FromBody] CreateNewSalaryRequest request)
    {
        var createdSalary = await _salaryService.CreateSalary(request);
        return createdSalary;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BaseResponse<SalaryResponse>>> UpdateSalary(int id, [FromBody] UpdateNewSalaryRequest request)
    {
        return await _salaryService.UpdateSalary(id, request);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponse<SalaryResponse>>> DeleteSalary(int id)
    {
        return await _salaryService.DeleteSalary(id);
    }
}