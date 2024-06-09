using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;
using ClinicBookingSystem_Service.Models.Request.Salary;
using ClinicBookingSystem_Service.Models.Response.Salary;
using ClinicBookingSystem_Service.Models.Response.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Service
{
    public class SalaryService : ISalaryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SalaryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<SalaryResponse>> CreateSalary(CreateNewSalaryRequest request)
        {
            var salary = _mapper.Map<Salary>(request);
            await _unitOfWork.SalaryRepository.AddAsync(salary);
            await _unitOfWork.SaveChangesAsync();
            var newSalaryDto = _mapper.Map<SalaryResponse>(salary);
            return new BaseResponse<SalaryResponse>("Add salary successfully", StatusCodeEnum.OK_200, newSalaryDto);
        }

        public async Task<BaseResponse<SalaryResponse>> DeleteSalary(int id)
        {
            var salary = await _unitOfWork.SalaryRepository.DeleteSalary(id);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<SalaryResponse>(salary);
            return new BaseResponse<SalaryResponse>("Delete salary successfully", StatusCodeEnum.OK_200, result);
        }

        public async Task<BaseResponse<IEnumerable<SalaryResponse>>> GetAllSalaries()
        {
            IEnumerable<Salary> salaries = await _unitOfWork.SalaryRepository.GetAllAsync();
            var salariesDto = _mapper.Map<IEnumerable<SalaryResponse>>(salaries);
            return new BaseResponse<IEnumerable<SalaryResponse>>("Get salaries successfully", StatusCodeEnum.OK_200,
                salariesDto);
        }


        public async Task<BaseResponse<SalaryResponse>> GetSalaryById(int id)
        {
            var salary = await _unitOfWork.SalaryRepository.GetByIdAsync(id);
            var salaryDto = _mapper.Map<SalaryResponse>(salary);
            return new BaseResponse<SalaryResponse>("Get salary by id successfully", StatusCodeEnum.OK_200, salaryDto);
        }

        public async Task<BaseResponse<SalaryResponse>> UpdateSalary(int id, UpdateNewSalaryRequest request)
        {
            var existSalary = await _unitOfWork.SalaryRepository.GetByIdAsync(id);
            _mapper.Map(request, existSalary);
            await _unitOfWork.SalaryRepository.UpdateAsync(existSalary);
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<SalaryResponse>(existSalary);
            return new BaseResponse<SalaryResponse>("Update successfully", StatusCodeEnum.OK_200, result);
        }
    }
}
