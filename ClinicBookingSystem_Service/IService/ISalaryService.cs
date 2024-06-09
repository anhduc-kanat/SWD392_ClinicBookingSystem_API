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
        public Task<BaseResponse<IEnumerable<SalaryResponse>>> GetAllSalaries();
        public Task<BaseResponse<SalaryResponse>> GetSalaryById(int id);
        public Task<BaseResponse<SalaryResponse>> CreateSalary(CreateNewSalaryRequest request);
        public Task<BaseResponse<SalaryResponse>> DeleteSalary(int id);
        public Task<BaseResponse<SalaryResponse>> UpdateSalary(int id, UpdateNewSalaryRequest request);
    }
}
