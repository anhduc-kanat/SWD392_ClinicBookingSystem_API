using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;
using ClinicBookingSystem_Service.Models.Request.MedicalRecord;
using ClinicBookingSystem_Service.Models.Response.MedicalRecord;
using ClinicBookingSystem_Service.Models.Response.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Service
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MedicalRecordService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        

        public async Task<BaseResponse<CreateMedicalRecordResponse>> AddMedicalRecord(CreateMedicalRecordRequest request)
        {
            try
            {
                UserProfile userProfile = await _unitOfWork.UserProfileRepository.GetByIdAsync(request.UserProfileId);
                MedicalRecord data = _mapper.Map<MedicalRecord>(request);
                data.UserProfile = userProfile;
                await _unitOfWork.MedicalRecordRepository.AddAsync(data);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<CreateMedicalRecordResponse>("Successfully", StatusCodeEnum.Created_201);
            }
            catch (Exception ex)
            {

                return new BaseResponse<CreateMedicalRecordResponse>("Medical Record  " + ex.Message, StatusCodeEnum.InternalServerError_500);

            }
        }

        public async Task<BaseResponse<DeleteMedicalRecordResponse>> DeleteMedicakRecord(int id)
        {
            try
            {
                MedicalRecord medicalRecord = await _unitOfWork.MedicalRecordRepository.GetByIdAsync(id);
                if (medicalRecord == null)
                {
                    return new BaseResponse<DeleteMedicalRecordResponse>("Medical Record not found", StatusCodeEnum.BadRequest_400);
                }
                await _unitOfWork.MedicalRecordRepository.DeleteAsync(medicalRecord);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<DeleteMedicalRecordResponse>("Successfully", StatusCodeEnum.Created_201);

            }
            catch (Exception ex)
            {
                return new BaseResponse<DeleteMedicalRecordResponse>("Medical Record Service " + ex.Message, StatusCodeEnum.InternalServerError_500);

            }
        }

        public async Task<BaseResponse<GetMedicalReportResponse>> GetMedicalRecord(int id)
        {
            try
            {
                MedicalRecord medicalRecord = await _unitOfWork.MedicalRecordRepository.GetByIdAsync(id);

                if (medicalRecord == null)
                {
                    return new BaseResponse<GetMedicalReportResponse>("Medical Record not found", StatusCodeEnum.BadRequest_400);
                }
                var response = _mapper.Map< GetMedicalReportResponse>(medicalRecord);
                return new BaseResponse<GetMedicalReportResponse>("Successfully", StatusCodeEnum.OK_200, response);

            }
            catch (Exception ex)
            {

                return new BaseResponse<GetMedicalReportResponse>("Medical Record Service " + ex.Message, StatusCodeEnum.InternalServerError_500);

            }
        }

        public async Task<BaseResponse<IEnumerable<GetMedicalReportResponse>>> GetMedicalRecords()
        {
            try
            {
                IEnumerable<MedicalRecord> medicalRecords = await _unitOfWork.MedicalRecordRepository.GetAllAsync();
                var response = _mapper.Map<IEnumerable<GetMedicalReportResponse>>(medicalRecords);
                return new BaseResponse<IEnumerable<GetMedicalReportResponse>>("Successfully", StatusCodeEnum.Created_201, response);

            }
            catch (Exception ex)
            {

                return new BaseResponse<IEnumerable<GetMedicalReportResponse>>("Medical Record Service " + ex.Message, StatusCodeEnum.InternalServerError_500);

            }
        }

        public async Task<BaseResponse<UpdateMedicalRecordResponse>> UpdateMedicalRecord(int id, UpdateMedicalRecordRequest request)
        {
            try
            {
                UserProfile userProfile = await _unitOfWork.UserProfileRepository.GetByIdAsync(request.UserProfileId);
                MedicalRecord medicalRecord = await _unitOfWork.MedicalRecordRepository.GetByIdAsync(id);
                MedicalRecord data = _mapper.Map(request, medicalRecord);
                data.UserProfile = userProfile;
                await _unitOfWork.MedicalRecordRepository.UpdateAsync(data);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResponse<UpdateMedicalRecordResponse>("Successfully", StatusCodeEnum.Created_201);
            }
            catch (Exception ex)
            {

                return new BaseResponse<UpdateMedicalRecordResponse>("Medical Record Service " + ex.Message, StatusCodeEnum.InternalServerError_500);

            }
        }
    }
}
