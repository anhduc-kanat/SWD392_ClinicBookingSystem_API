using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Clinic_Owner;
using ClinicBookingSystem_Service.Models.Response.Clinic_Owner;

namespace ClinicBookingSystem_Service.IService;

public interface IClinicOwnerService
{
    Task<BaseResponse<GetClinicOwnerResponse>> GetClinicOwner(int id);
    Task<BaseResponse<GetClinicOwnerResponse>> CreateClinicOwner(CreateClinicOwnerRequest request);
    Task<BaseResponse<GetClinicOwnerResponse>> UpdateClinicOwner(int id ,UpdateClinicOwnerRequest request);
    Task<BaseResponse<GetClinicOwnerResponse>> DeleteClinicOwner(int id);
}