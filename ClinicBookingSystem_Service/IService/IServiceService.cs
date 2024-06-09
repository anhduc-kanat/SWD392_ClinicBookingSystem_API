using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Service;
using ClinicBookingSystem_Service.Models.Request.Slot;
using ClinicBookingSystem_Service.Models.Response.Service;
using ClinicBookingSystem_Service.Models.Response.Slot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.IService
{
    public interface IServiceService
    {
        public Task<BaseResponse<IEnumerable<ServiceResponse>>> GetAllServices();
        public Task<BaseResponse<ServiceResponse>> GetServiceById(int id);
        public Task<BaseResponse<ServiceResponse>> CreateService(CreateServiceRequest request);
        public Task<BaseResponse<ServiceResponse>> DeleteService(int id);
        public Task<BaseResponse<ServiceResponse>> UpdateService(int id, UpdateServiceRequest request);
    }
}
