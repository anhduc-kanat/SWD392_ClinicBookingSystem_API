using ClinicBookingSystem_Service.Dtos.Request;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Staff;
using ClinicBookingSystem_Service.Models.Response.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpPost]
        [Route("staff/create-staff")]
        public async Task<ActionResult<BaseResponse<CreateStaffResponse>>> CreateStaff(CreateStaffRequest request)
        {
            var response = await _staffService.CreateStaff(request);
            return response;
        }

        [HttpPut("staff/update-staff/{id}")]
        public async Task<ActionResult<BaseResponse<UpdateStaffResponse>>> UpdateStaff(int id, UpdateStaffRequest request)
        {
            var response = await _staffService.UpdateStaff(id, request);
            return response;
        }

        [HttpGet("staff/get-staff/{id}")]
        public async Task<ActionResult<BaseResponse<GetStaffByIdResponse>>> GetStaffById(int id)
        {
            var response = await _staffService.GetStaffById(id);
            return response;
        }

        [HttpGet("staff/get-staffs")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetAllStaffsResponse>>>> GetAllStaffs()
        {
            var response = await _staffService.GetAllStaffs();
            return response;
        }

        [HttpDelete("staff/delete-staff/{id}")]
        public async Task<ActionResult<BaseResponse<DeleteStaffResponse>>> DeleteStaff(int id)
        {
            var response = await _staffService.DeleteStaff(id);
            return response;
        }
    }
}
