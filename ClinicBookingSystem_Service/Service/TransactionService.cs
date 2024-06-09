using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Transaction;
using ClinicBookingSystem_Service.Models.Response.Transaction;

namespace ClinicBookingSystem_Service.Service;

public class TransactionService : ITransactionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    //Create transaction
    public async Task<BaseResponse<CreateTransactionResponse>> CreateTransaction(CreateTransactionRequest request)
    {
        var transaction = _mapper.Map<Transaction>(request);
        await _unitOfWork.TransactionRepository.AddAsync(transaction);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaseResponse<CreateTransactionResponse>>(transaction);
    }
    //get transaction by id
    public async Task<BaseResponse<GetTransactionResponse>> GetTransactionById(int id)
    {
        var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(id);
        return _mapper.Map<BaseResponse<GetTransactionResponse>>(transaction);
    }
    //update transaction
    public async Task<BaseResponse<UpdateTransactionResponse>> UpdateTransaction(int id, UpdateTransactionRequest request)
    {
        var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(id);
        _mapper.Map(request, transaction);
        _unitOfWork.TransactionRepository.UpdateAsync(transaction);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaseResponse<UpdateTransactionResponse>>(transaction);
    }
    //delete transaction
    public async Task<BaseResponse<DeleteTransactionResponse>> DeleteTransaction(int id)
    {
        var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(id);
        await _unitOfWork.TransactionRepository.DeleteAsync(transaction);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<BaseResponse<DeleteTransactionResponse>>(transaction);
    }
    //get all transactions
    public async Task<BaseResponse<IEnumerable<GetTransactionResponse>>> GetAllTransaction()
    {
        var transactions = await _unitOfWork.TransactionRepository.GetAllAsync();
        return _mapper.Map<BaseResponse<IEnumerable<GetTransactionResponse>>>(transactions);
    }
}