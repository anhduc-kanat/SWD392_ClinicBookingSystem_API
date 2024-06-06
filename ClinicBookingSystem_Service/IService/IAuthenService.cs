using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Authen;
using ClinicBookingSystem_Service.Models.Response.Authen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.IService
{
    public interface IAuthenService
    {
        Task<BaseResponse<LoginResponse>> LoginWithJwtTokenAsync(LoginRequest request);
        Task<BaseResponse<LoginResponse>> RenewJwtTokenAsync(RenewTokenRequest request);

    }
}
