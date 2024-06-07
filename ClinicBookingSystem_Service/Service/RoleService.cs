using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;
using ClinicBookingSystem_Service.Models.Request.Role;
using ClinicBookingSystem_Service.Models.Response.Role;

namespace ClinicBookingSystem_Service.Service
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<GetRoleResponse>> GetRoleByName(string roleName)
        {
            GetRoleResponse response = _mapper.Map<GetRoleResponse>(await _unitOfWork.RoleRepository.GetRoleByName(roleName));
            return new BaseResponse<GetRoleResponse>("Successful", StatusCodeEnum.OK_200, response);
        }
        private async Task<BaseResponse<CreateRoleResponse>> CreateRole(CreateRoleRequest request)
        {
            try
            {
                Role role = _mapper.Map<Role>(request);
                var createdRole = await _unitOfWork.RoleRepository.AddAsync(role);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<CreateRoleResponse>("Create Role Successfully!", StatusCodeEnum.Created_201);
            }
            catch (Exception ex)
            {
                return new BaseResponse<CreateRoleResponse>("Error at CreateRole Service: " + ex.Message, StatusCodeEnum.InternalServerError_500);
            }
        }
    }
}
