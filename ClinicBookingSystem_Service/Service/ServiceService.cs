using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;
using ClinicBookingSystem_Service.Models.Request.Service;
using ClinicBookingSystem_Service.Models.Response.Service;
using ClinicBookingSystem_Service.Models.Response.Slot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Service
{
    public class ServiceService:IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ServiceResponse>> CreateService(CreateServiceRequest request)
        {
            var service = _mapper.Map<ClinicBookingSystem_BusinessObject.Entities.Service>(request);
            await _unitOfWork.ServiceRepository.AddAsync(service);
            await _unitOfWork.SaveChangesAsync();
            var newServiceDto = _mapper.Map<ServiceResponse>(service);
            return new BaseResponse<ServiceResponse>("Add service successfully", StatusCodeEnum.OK_200, newServiceDto);
        }

        public async Task<BaseResponse<ServiceResponse>> DeleteService(int id)
        {
            var service = await _unitOfWork.ServiceRepository.DeleteService(id);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<ServiceResponse>(service);
            return new BaseResponse<ServiceResponse>("Delete service successfully", StatusCodeEnum.OK_200, result);
        }

        public async Task<BaseResponse<IEnumerable<ServiceResponse>>> GetAllServices()
        {
            IEnumerable<ClinicBookingSystem_BusinessObject.Entities.Service> services = await _unitOfWork.ServiceRepository.GetAllAsync();
            var servicesDto = _mapper.Map<IEnumerable<ServiceResponse>>(services);
            return new BaseResponse<IEnumerable<ServiceResponse>>("Get services successfully", StatusCodeEnum.OK_200,
                servicesDto);
        }

        public async Task<BaseResponse<ServiceResponse>> GetServiceById(int id)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(id);
            var serviceDto = _mapper.Map<ServiceResponse>(service);
            return new BaseResponse<ServiceResponse>("Get service by id successfully", StatusCodeEnum.OK_200, serviceDto);
        }

        public async Task<BaseResponse<ServiceResponse>> UpdateService(int id, UpdateServiceRequest request)
        {
            var existService = await _unitOfWork.ServiceRepository.GetByIdAsync(id);
            _mapper.Map(request, existService);
            await _unitOfWork.ServiceRepository.UpdateAsync(existService);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<ServiceResponse>(existService);
            return new BaseResponse<ServiceResponse>("Update successfully", StatusCodeEnum.OK_200, result);
        }
    }
}
