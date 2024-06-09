using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.MedicalRecord;
using ClinicBookingSystem_Service.Models.Request.Relative;
using ClinicBookingSystem_Service.Models.Request.UserProfile;
using ClinicBookingSystem_Service.Models.Response.MedicalRecord;
using ClinicBookingSystem_Service.Models.Response.UserProfile;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers
{
    [Route("api/medical-record")]
    [ApiController]
    public class MedicalRecordController
    {
        private readonly IMedicalRecordService _medicalRecordService;
        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        [HttpPost]
        [Route("new")]
        public async Task<ActionResult<BaseResponse<CreateMedicalRecordResponse>>> Create([FromBody] CreateMedicalRecordRequest request)
        {
            return await _medicalRecordService.AddMedicalRecord(request);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<BaseResponse<UpdateMedicalRecordResponse>>> Update(int id, [FromBody] UpdateMedicalRecordRequest request)
        {
            return await _medicalRecordService.UpdateMedicalRecord(id, request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<BaseResponse<DeleteMedicalRecordResponse>>> Delete(int id)
        {
            return await _medicalRecordService.DeleteMedicakRecord(id);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<BaseResponse<GetMedicalReportResponse>>> GetById(int id)
        {
            var user = await _medicalRecordService.GetMedicalRecord(id);
            return user;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetMedicalReportResponse>>>> GetAll()
        {
            return await _medicalRecordService.GetMedicalRecords();

        }
    }
}