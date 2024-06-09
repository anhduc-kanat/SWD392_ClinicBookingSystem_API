using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Medicine;
using ClinicBookingSystem_Service.Models.Response.Medicine;

namespace ClinicBookingSystem_Service.Service;

public class MedicineService : IMedicineService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public MedicineService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    //Get all medicines
    public async Task<BaseResponse<IEnumerable<GetMedicineResponse>>> GetAllMedicine()
    {
        var medicines = await _unitOfWork.MedicineRepository.GetAllAsync();
        return _mapper.Map<BaseResponse<IEnumerable<GetMedicineResponse>>>(medicines);
    }
    //Get medicine by id
    public async Task<BaseResponse<GetMedicineResponse>> GetMedicineById(int id)
    {
        var medicine = await _unitOfWork.MedicineRepository.GetByIdAsync(id);
        return _mapper.Map<BaseResponse<GetMedicineResponse>>(medicine);
    }
    //Create medicine
    public async Task<BaseResponse<CreateMedicineResponse>> CreateMedicine(CreateMedicineRequest request)
    {
        var medicine = _mapper.Map<Medicine>(request);
        await _unitOfWork.MedicineRepository.AddAsync(medicine);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaseResponse<CreateMedicineResponse>>(medicine);
    }
    //Update medicine
    public async Task<BaseResponse<UpdateMedicineResponse>> UpdateMedicine(int id, UpdateMedicineRequest request)
    {
        var medicine = await _unitOfWork.MedicineRepository.GetByIdAsync(id);
        _mapper.Map(request, medicine);
        _unitOfWork.MedicineRepository.UpdateAsync(medicine);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaseResponse<UpdateMedicineResponse>>(medicine);
    }
    //Delete medicine
    public async Task<BaseResponse<DeleteMedicineResponse>> DeleteMedicine(int id)
    {
        var medicine = await _unitOfWork.MedicineRepository.GetByIdAsync(id);
        await _unitOfWork.MedicineRepository.DeleteAsync(medicine);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaseResponse<DeleteMedicineResponse>>(medicine);
    }
    
}