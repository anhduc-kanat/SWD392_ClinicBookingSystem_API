using ClinicBookingSystem_BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Response.Role;

namespace ClinicBookingSystem_Service.IService
{
    public interface IRoleService
    {
        Task<BaseResponse<GetRoleResponse>> GetRoleByName(string roleName);
    }
}
