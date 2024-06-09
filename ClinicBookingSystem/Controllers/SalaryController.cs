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

[ApiController]
[Route("api/salary")]
public class SalaryController : ControllerBase
{
    private readonly ISalaryService _salaryService;

    public SalaryController(ISalaryService salaryService)
    {
        _salaryService = salaryService;
    }

    [HttpGet]
    [Route("get-all-salaries")]
    public async Task<ActionResult<BaseResponse<IEnumerable<GetSalaryResponse>>>> GetSalaries()
    {
        var salaries = await _salaryService.GetAllSalaries();
        return Ok(salaries);
    }

    [HttpGet]
    [Route("get-salary-by-id/{id}")]
    public async Task<ActionResult<BaseResponse<GetSalaryResponse>>> GetSalary(int id)
    {
        var salary = await _salaryService.GetSalaryById(id);

        return Ok(salary);
    }

    [HttpPost]
    [Route("create-salary")]
    public async Task<ActionResult<BaseResponse<CreateSalaryResponse>>> AddSalary([FromBody] CreateNewSalaryRequest request)
    {
        var createdSalary = await _salaryService.CreateSalary(request);
        return createdSalary;
    }

    [HttpPut]
    [Route("update-salary/{id}")]
    public async Task<ActionResult<BaseResponse<UpdateSalaryResponse>>> UpdateSalary(int id, [FromBody] UpdateNewSalaryRequest request)
    {
        return await _salaryService.UpdateSalary(id, request);
    }

    [HttpDelete]
    [Route("delete-salary/{id}")]
    public async Task<ActionResult<BaseResponse<DeleteSalaryResponse>>> DeleteSalary(int id)
    {
        return await _salaryService.DeleteSalary(id);
    }
}