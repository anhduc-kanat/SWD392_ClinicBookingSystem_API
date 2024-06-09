using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Salary;
using ClinicBookingSystem_Service.Models.Request.Service;
using ClinicBookingSystem_Service.Models.Response.Salary;
using ClinicBookingSystem_Service.Models.Response.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.IService
{
    public interface ISalaryService
    {
        Task<BaseResponse<CreateSalaryResponse>> CreateSalary(CreateNewSalaryRequest request);
        Task<BaseResponse<DeleteSalaryResponse>> DeleteSalary(int id);
        Task<BaseResponse<IEnumerable<GetSalaryResponse>>> GetAllSalaries();
        Task<BaseResponse<GetSalaryResponse>> GetSalaryById(int id);
        Task<BaseResponse<UpdateSalaryResponse>> UpdateSalary(int id, UpdateNewSalaryRequest request);
    }
}
