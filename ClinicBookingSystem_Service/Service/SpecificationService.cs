using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;
using ClinicBookingSystem_Service.Models.Request.Specification;
using ClinicBookingSystem_Service.Models.Response.Salary;
using ClinicBookingSystem_Service.Models.Response.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Service
{
    public class SpecificationService : ISpecificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SpecificationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<SpecificationResponse>> CreateSpecification(CreateSpecificationRequest request)
        {
            var specification = _mapper.Map<Specification>(request);
            await _unitOfWork.SpecificationRepository.AddAsync(specification);
            await _unitOfWork.SaveChangesAsync();
            var newSpecificationDto = _mapper.Map<SpecificationResponse>(specification);
            return new BaseResponse<SpecificationResponse>("Add specification successfully", StatusCodeEnum.OK_200, newSpecificationDto);
        }

        public async Task<BaseResponse<SpecificationResponse>> DeleteSpecification(int id)
        {
            var specification = await _unitOfWork.SpecificationRepository.DeleteSpecification(id);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<SpecificationResponse>(specification);
            return new BaseResponse<SpecificationResponse>("Delete specification successfully", StatusCodeEnum.OK_200, result);
        }

        public async Task<BaseResponse<IEnumerable<SpecificationResponse>>> GetAllSpecifications()
        {
            IEnumerable<Specification> specifications = await _unitOfWork.SpecificationRepository.GetAllAsync();
            var specificationsDto = _mapper.Map<IEnumerable<SpecificationResponse>>(specifications);
            return new BaseResponse<IEnumerable<SpecificationResponse>>("Get specifications successfully", StatusCodeEnum.OK_200,
                specificationsDto);
        }

        public async Task<BaseResponse<SpecificationResponse>> GetSpecificationById(int id)
        {
            var specification = await _unitOfWork.SpecificationRepository.GetByIdAsync(id);
            var specificationDto = _mapper.Map<SpecificationResponse>(specification);
            return new BaseResponse<SpecificationResponse>("Get specification by id successfully", StatusCodeEnum.OK_200, specificationDto);
        }

        public async Task<BaseResponse<SpecificationResponse>> UpdateSpecification(int id, UpdateSpecificationRequest request)
        {
            var existSpecification = await _unitOfWork.SpecificationRepository.GetByIdAsync(id);
            _mapper.Map(request, existSpecification);
            await _unitOfWork.SpecificationRepository.UpdateAsync(existSpecification);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<SpecificationResponse>(existSpecification);
            return new BaseResponse<SpecificationResponse>("Update successfully", StatusCodeEnum.OK_200, result);
        }
    }
}
