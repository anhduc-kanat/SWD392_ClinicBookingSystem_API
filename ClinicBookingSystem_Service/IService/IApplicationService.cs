using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Application;
using ClinicBookingSystem_Service.Models.Response.Application;

namespace ClinicBookingSystem_Service.IService;

public interface IApplicationService
{
    Task<BaseResponse<IEnumerable<ApplicationResponse>>> GetAllApplications();
    Task<BaseResponse<ApplicationResponse>> GetApplicationById(int id);
    Task<BaseResponse<ApplicationResponse>> CreateApplication(CreateNewApplicationRequest application);
    Task<BaseResponse<ApplicationResponse>> UpdateApplication(int id, UpdateApplicationRequest application);
    Task<BaseResponse<ApplicationResponse>> DeleteApplication(int id);
}