using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Clinic_Owner;
using ClinicBookingSystem_Service.Models.Response.Clinic_Owner;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicOwnerController : ControllerBase
    {
        private readonly IClinicOwnerService _clinicOwnerService;
        public ClinicOwnerController(IClinicOwnerService clinicService)
        {
            _clinicOwnerService = clinicService;
        }

        [HttpGet]
        [Route("get-clinic-owner/{id}")]
        public async Task<ActionResult<BaseResponse<GetClinicOwnerResponse>>> GetClinicOwner(int id)
        {
            return await _clinicOwnerService.GetClinicOwner(id);
        }

        [HttpPost]
        [Route("create-clinic-owner")]
        public async Task<ActionResult<BaseResponse<GetClinicOwnerResponse>>> CreateClinicOwner(CreateClinicOwnerRequest request)
        {
            return await _clinicOwnerService.CreateClinicOwner(request);
        }

        [HttpPut("update-clinic-owner/{id}")]
        public async Task<ActionResult<BaseResponse<GetClinicOwnerResponse>>> UpdateClinicOwner(int id, UpdateClinicOwnerRequest request)
        {
            return await _clinicOwnerService.UpdateClinicOwner(id, request);
        }

        [HttpDelete("delete-clinic-owner/{id}")]
        public async Task<ActionResult<BaseResponse<GetClinicOwnerResponse>>> DeleteClinicOwner(int id)
        {
            return await _clinicOwnerService.DeleteClinicOwner(id);
        }
    }
}