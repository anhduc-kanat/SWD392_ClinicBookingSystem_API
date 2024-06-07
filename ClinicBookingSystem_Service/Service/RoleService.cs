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
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<IEnumerable<GetRoleResponse>>> GetRoleByName(string roleName)
        {
            var response = _mapper.Map<IEnumerable<GetRoleResponse>>(await _unitOfWork.RoleRepository.GetRoleByName(roleName));
            return new BaseResponse<IEnumerable<GetRoleResponse>>("Successful", StatusCodeEnum.OK_200, response);
        }
        
        public async Task<BaseResponse<CreateRoleResponse>> CreateRole(CreateRoleRequest request)
        {
                Role role = _mapper.Map<Role>(request);
                await _unitOfWork.RoleRepository.AddAsync(role);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<CreateRoleResponse>("Create Role Successfully!", StatusCodeEnum.Created_201);
        }
        
        public async Task<BaseResponse<UpdateRoleResponse>> UpdateRoleResponse(UpdateRoleRequest request)
        {
                Role role = _mapper.Map<Role>(request);
                await _unitOfWork.RoleRepository.UpdateAsync(role);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<UpdateRoleResponse>("Update Role Successfully!", StatusCodeEnum.OK_200);
        }
        public async Task<BaseResponse<DeleteRoleResponse>> DeleteRoleResponse(int id)
        {
                Role role = await _unitOfWork.RoleRepository.GetByIdAsync(id);
                await _unitOfWork.RoleRepository.DeleteAsync(role);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<DeleteRoleResponse>("Delete Role Successfully!", StatusCodeEnum.OK_200);
        }
    }
}
