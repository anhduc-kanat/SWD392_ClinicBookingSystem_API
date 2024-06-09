using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Medicine;
using ClinicBookingSystem_Service.Models.Response.Medicine;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers;

[ApiController]
[Route("api/medicine")]
public class MedicineController : ControllerBase
{
    private readonly IMedicineService _medicineService;
    public MedicineController(IMedicineService medicineService)
    {
        _medicineService = medicineService;
    }
    // GET: api/medicine
    [HttpGet]
    [Route("get-all-medicines")]
    public async Task<ActionResult<BaseResponse<IEnumerable<GetMedicineResponse>>>> GetAllMedicine()
    {
        var result = await _medicineService.GetAllMedicine();
        return Ok(result);
    }
    // GET: api/medicine/{id}
    [HttpGet]
    [Route("get-medicine-by-id/{id}")]
    public async Task<ActionResult<BaseResponse<GetMedicineResponse>>> GetMedicineById(int id)
    {
        var result = await _medicineService.GetMedicineById(id);
        return Ok(result);
    }
    // POST: api/medicine
    [HttpPost]
    [Route("create-medicine")]
    public async Task<ActionResult<BaseResponse<CreateMedicineResponse>>> CreateMedicine([FromBody] CreateMedicineRequest request)
    {
        var result = await _medicineService.CreateMedicine(request);
        return Ok(result);
    }
    // PUT: api/medicine/{id}
    [HttpPut]
    [Route("update-medicine/{id}")]
    public async Task<ActionResult<BaseResponse<UpdateMedicineResponse>>> UpdateMedicine(int id, [FromBody] UpdateMedicineRequest request)
    {
        var result = await _medicineService.UpdateMedicine(id, request);
        return Ok(result);
    }
    // DELETE: api/medicine/{id}
    [HttpDelete]
    [Route("delete-medicine/{id}")]
    public async Task<ActionResult<BaseResponse<DeleteMedicineResponse>>> DeleteMedicine(int id)
    {
        var result = await _medicineService.DeleteMedicine(id);
        return Ok(result);
    }
    
}