using AutoMapper;
using Azure.Core;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.Common.Utils;
using ClinicBookingSystem_Service.Dtos.Request;
using ClinicBookingSystem_Service.IServices;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;
using ClinicBookingSystem_Service.Models.Request.Dentist;
using ClinicBookingSystem_Service.Models.Response.Dentist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Services
{
    public class DentistService : IDentistService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DentistService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<CreateDentistResponse>> CreateDentist(CreateDentistRequest request)
        {
            try
            {
                HashPassword hash = new HashPassword();
                request.Password = hash.EncodePassword(request.Password);
                User user = _mapper.Map<User>(request);
                Role role = await _unitOfWork.RoleRepository.GetRoleByName("DENTIST");
                user.Role = role;
                var createdUser = await _unitOfWork.DentistRepository.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<CreateDentistResponse>("Create Dentist Successfully!", StatusCodeEnum.Created_201);
            }
            catch (Exception ex)
            {
                return new BaseResponse<CreateDentistResponse>("Error at CreateDentist Service: " + ex.Message, StatusCodeEnum.InternalServerError_500);
            }
            
        }

        public async Task<BaseResponse<DeleteDentistResponse>> DeleteDentist(int id)
        {
            try
            {
                User dentist = await _unitOfWork.DentistRepository.GetByIdAsync(id);
                await _unitOfWork.DentistRepository.DeleteAsync(dentist);
                var response = _mapper.Map<DeleteDentistResponse>(dentist);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<DeleteDentistResponse>("Delete Dentist Successfully!", StatusCodeEnum.OK_200, response);
            }
            catch (Exception ex)
            {
                return new BaseResponse<DeleteDentistResponse>("Error at DeleteDentist Service: " + ex.Message, StatusCodeEnum.InternalServerError_500);
            }
        }

        public async Task<BaseResponse<IEnumerable<GetAllDentistsResponse>>> GetAllDentists()
        {
            try
            {
                IEnumerable<User> dentists = await _unitOfWork.DentistRepository.GetDentistsByRole();
                IEnumerable<GetAllDentistsResponse> response = _mapper.Map<IEnumerable<GetAllDentistsResponse>>(dentists);
                return new BaseResponse<IEnumerable<GetAllDentistsResponse>>("Get All Dentists successfully", StatusCodeEnum.OK_200, response);
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<GetAllDentistsResponse>>("Error at GetAllDentists Service: " + ex.Message, StatusCodeEnum.InternalServerError_500);
            }
        }

        public async Task<BaseResponse<GetDentistByIdResponse>> GetDentistById(int id)
        {
            try
            {
                User dentist = await _unitOfWork.DentistRepository.GetByIdAsync(id);
                GetDentistByIdResponse response = _mapper.Map<GetDentistByIdResponse>(dentist);
                return new BaseResponse<GetDentistByIdResponse>("Get Dentist By ID successfully!", StatusCodeEnum.OK_200, response);
            }
            catch (Exception ex)
            {
                return new BaseResponse<GetDentistByIdResponse>("Error at GetDentistById Service: " + ex.Message , StatusCodeEnum.InternalServerError_500);
            }
        }

        public async Task<BaseResponse<UpdateDentistResponse>> UpdateDentist(int id, UpdateDentistRequest request)
        {
            try
            {
                /*HashPassword hash = new HashPassword();
                request.Password = hash.EncodePassword(request.Password);*/
                User dentist = await _unitOfWork.DentistRepository.GetByIdAsync(id);
                _mapper.Map(request, dentist);
                User updatedDentist = await _unitOfWork.DentistRepository.UpdateAsync(dentist);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<UpdateDentistResponse>("Update Dentist Successfully!", StatusCodeEnum.OK_200);
            }
            catch (Exception ex)
            {
                return new BaseResponse<UpdateDentistResponse>("Error at UpdateDentist Service: " + ex.Message, StatusCodeEnum.InternalServerError_500);
            }
        }
    }
}
