using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Medicine;
using ClinicBookingSystem_Service.Models.Response.Medicine;

namespace ClinicBookingSystem_Service.IService;

public interface IMedicineService
{
    // Get all medicines
    Task<BaseResponse<IEnumerable<GetMedicineResponse>>> GetAllMedicine();
    // Get medicine by id
    Task<BaseResponse<GetMedicineResponse>> GetMedicineById(int id);
    // Create medicine
    Task<BaseResponse<CreateMedicineResponse>> CreateMedicine(CreateMedicineRequest request);
    // Update medicine
    Task<BaseResponse<UpdateMedicineResponse>> UpdateMedicine(int id, UpdateMedicineRequest request);
    // Delete medicine
    Task<BaseResponse<DeleteMedicineResponse>> DeleteMedicine(int id);
}