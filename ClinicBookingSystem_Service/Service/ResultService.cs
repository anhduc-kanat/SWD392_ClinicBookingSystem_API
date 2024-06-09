using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Result;
using ClinicBookingSystem_Service.Models.Response.Result;

namespace ClinicBookingSystem_Service.Service;

public class ResultService : IResultService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ResultService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    //Get all results
    public async Task<BaseResponse<IEnumerable<GetResultResponse>>> GetAllResult()
    {
        var results = await _unitOfWork.ResultRepository.GetAllAsync();
        return _mapper.Map<BaseResponse<IEnumerable<GetResultResponse>>>(results);
    }
    //Get result by id
    public async Task<BaseResponse<GetResultResponse>> GetResultById(int id)
    {
        var result = await _unitOfWork.ResultRepository.GetByIdAsync(id);
        return _mapper.Map<BaseResponse<GetResultResponse>>(result);
    }
    //Create new result
    public async Task<BaseResponse<CreateResultResponse>> CreateResult(CreateResultRequest request)
    {
        var result = _mapper.Map<Result>(request);
        await _unitOfWork.ResultRepository.AddAsync(result);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaseResponse<CreateResultResponse>>(request);
    }
    //Update result
    public async Task<BaseResponse<UpdateResultResponse>> UpdateResult(int id, UpdateResultRequest request)
    {
        var result = await _unitOfWork.ResultRepository.GetByIdAsync(id);
        _mapper.Map(request, result);
        _unitOfWork.ResultRepository.UpdateAsync(result);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaseResponse<UpdateResultResponse>>(request);
    }
    //Delete result
    public async Task<BaseResponse<DeleteResultResponse>> DeleteResult(int id)
    {
        var result = await _unitOfWork.ResultRepository.GetByIdAsync(id);
        await _unitOfWork.ResultRepository.DeleteAsync(result);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaseResponse<DeleteResultResponse>>(result);
    }
    
}