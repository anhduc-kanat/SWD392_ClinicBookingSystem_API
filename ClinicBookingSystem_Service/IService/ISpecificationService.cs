using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Salary;
using ClinicBookingSystem_Service.Models.Request.Specification;
using ClinicBookingSystem_Service.Models.Response.Salary;
using ClinicBookingSystem_Service.Models.Response.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.IService
{
    public interface ISpecificationService
    {
        public Task<BaseResponse<IEnumerable<SpecificationResponse>>> GetAllSpecifications();
        public Task<BaseResponse<SpecificationResponse>> GetSpecificationById(int id);
        public Task<BaseResponse<SpecificationResponse>> CreateSpecification(CreateSpecificationRequest request);
        public Task<BaseResponse<SpecificationResponse>> DeleteSpecification(int id);
        public Task<BaseResponse<SpecificationResponse>> UpdateSpecification(int id, UpdateSpecificationRequest request);
    }
}
