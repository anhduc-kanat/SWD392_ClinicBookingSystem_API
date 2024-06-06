using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;
using ClinicBookingSystem_Service.Models.Request.Application;
using ClinicBookingSystem_Service.Models.Response.Application;
using ClinicBookingSystem_Service.Models.Response.User;

namespace ClinicBookingSystem_Service.Service;

public class ApplicationService : IApplicationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ApplicationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseResponse<IEnumerable<ApplicationResponse>>> GetAllApplications()
    {
        IEnumerable<Application> applications = await _unitOfWork.ApplicationRepository.GetAllAsync();
        var result = _mapper.Map<IEnumerable<ApplicationResponse>>(applications);
        return new BaseResponse<IEnumerable<ApplicationResponse>>("Get all applications successfully", StatusCodeEnum.OK_200, result);
    }

    public async Task<BaseResponse<ApplicationResponse>> GetApplicationById(int id)
    {
        Application application = await _unitOfWork.ApplicationRepository.GetByIdAsync(id);
        var result = _mapper.Map<ApplicationResponse>(application);
        return new BaseResponse<ApplicationResponse>("Get application by id successfully", StatusCodeEnum.OK_200, result);
    }

    public async Task<BaseResponse<ApplicationResponse>> CreateApplication(CreateNewApplicationRequest request)
    {
        Application application = _mapper.Map<Application>(request);
        await _unitOfWork.ApplicationRepository.AddAsync(application);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<ApplicationResponse>(application);
        return new BaseResponse<ApplicationResponse>("Create application successfully", StatusCodeEnum.Created_201, result);
    }
    public async Task<BaseResponse<ApplicationResponse>> UpdateApplication(int id, UpdateApplicationRequest request)
    {
        Application application = await _unitOfWork.ApplicationRepository.GetByIdAsync(id);
        _mapper.Map(request, application);
        await _unitOfWork.ApplicationRepository.UpdateAsync(application);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<ApplicationResponse>(application);
        return new BaseResponse<ApplicationResponse>("Update application successfully", StatusCodeEnum.OK_200, result);
    }
    public async Task<BaseResponse<ApplicationResponse>> DeleteApplication(int id)
    {
        Application application = await _unitOfWork.ApplicationRepository.GetByIdAsync(id);
        await _unitOfWork.ApplicationRepository.DeleteAsync(application);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<ApplicationResponse>(application);
        return new BaseResponse<ApplicationResponse>("Delete application successfully", StatusCodeEnum.OK_200, result);
    }
}