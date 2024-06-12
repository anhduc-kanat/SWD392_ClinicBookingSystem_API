using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;
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
        IEnumerable<Medicine> medicines = await _unitOfWork.MedicineRepository.GetAllAsync();
        return new BaseResponse<IEnumerable<GetMedicineResponse>>("Get all medicines successfully",
            StatusCodeEnum.OK_200,
            _mapper.Map<IEnumerable<GetMedicineResponse>>(medicines));
    }
    //Get medicine by id
    public async Task<BaseResponse<GetMedicineResponse>> GetMedicineById(int id)
    {
        Medicine medicine = await _unitOfWork.MedicineRepository.GetByIdAsync(id);
        return new BaseResponse<GetMedicineResponse>("Get medicine by id successfully",
            StatusCodeEnum.OK_200,
            _mapper.Map<GetMedicineResponse>(medicine));
    }
    //Create medicine
    public async Task<BaseResponse<CreateMedicineResponse>> CreateMedicine(CreateMedicineRequest request)
    {
        Medicine medicine = _mapper.Map<Medicine>(request);
        await _unitOfWork.MedicineRepository.AddAsync(medicine);
        await _unitOfWork.SaveChangesAsync();
        return new BaseResponse<CreateMedicineResponse>("Create medicine successfully",
            StatusCodeEnum.Created_201,
            _mapper.Map<CreateMedicineResponse>(medicine));
    }
    //Update medicine
    public async Task<BaseResponse<UpdateMedicineResponse>> UpdateMedicine(int id, UpdateMedicineRequest request)
    {
        Medicine medicine = await _unitOfWork.MedicineRepository.GetByIdAsync(id);
        _mapper.Map(request, medicine);
        _unitOfWork.MedicineRepository.UpdateAsync(medicine);
        await _unitOfWork.SaveChangesAsync();
        return new BaseResponse<UpdateMedicineResponse>("Update medicine successfully",
            StatusCodeEnum.OK_200,
            _mapper.Map<UpdateMedicineResponse>(medicine));
    }
    //Delete medicine
    public async Task<BaseResponse<DeleteMedicineResponse>> DeleteMedicine(int id)
    {
        Medicine medicine = await _unitOfWork.MedicineRepository.GetByIdAsync(id);
        await _unitOfWork.MedicineRepository.DeleteAsync(medicine);
        await _unitOfWork.SaveChangesAsync();
        return new BaseResponse<DeleteMedicineResponse>("Delete medicine successfully",
            StatusCodeEnum.OK_200,
            _mapper.Map<DeleteMedicineResponse>(medicine));
    }
    
}