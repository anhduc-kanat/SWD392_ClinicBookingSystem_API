using ClinicBookingSystem_Service.Dtos.Request;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Staff;
using ClinicBookingSystem_Service.Models.Response.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.IService
{
    public interface IStaffService
    {
        Task<BaseResponse<IEnumerable<GetAllStaffsResponse>>> GetAllStaffs();
        Task<BaseResponse<GetStaffByIdResponse>> GetStaffById(int id);
        Task<BaseResponse<CreateStaffResponse>> CreateStaff(CreateStaffRequest request);
        Task<BaseResponse<UpdateStaffResponse>> UpdateStaff(int id, UpdateStaffRequest request);
        Task<BaseResponse<DeleteStaffResponse>> DeleteStaff(int id);
    }
}
