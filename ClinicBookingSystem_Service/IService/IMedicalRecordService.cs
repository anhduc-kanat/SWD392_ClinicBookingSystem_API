using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.MedicalRecord;
using ClinicBookingSystem_Service.Models.Request.Relative;
using ClinicBookingSystem_Service.Models.Request.UserProfile;
using ClinicBookingSystem_Service.Models.Response.MedicalRecord;
using ClinicBookingSystem_Service.Models.Response.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.IService
{
    public interface IMedicalRecordService
    {
        Task<BaseResponse<CreateMedicalRecordResponse>> AddMedicalRecord(CreateMedicalRecordRequest request);
        Task<BaseResponse<UpdateMedicalRecordResponse>> UpdateMedicalRecord(int id, UpdateMedicalRecordRequest request);
        Task<BaseResponse<DeleteMedicalRecordResponse>> DeleteMedicakRecord(int id);
        Task<BaseResponse<IEnumerable<GetMedicalReportResponse>>> GetMedicalRecords();
        Task<BaseResponse<GetMedicalReportResponse>> GetMedicalRecord(int id);
    }
}
