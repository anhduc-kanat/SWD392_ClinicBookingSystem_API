using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.Transaction;
using ClinicBookingSystem_Service.Models.Response.Transaction;

namespace ClinicBookingSystem_Service.Mapping;

public class MappingTransaction : Profile
{
    public MappingTransaction()
    {
        CreateMap<Transaction, GetTransactionResponse>().ReverseMap();
        CreateMap<CreateTransactionRequest, Transaction>();
        CreateMap<UpdateTransactionRequest, Transaction>();
        CreateMap<Transaction, CreateTransactionResponse>().ReverseMap();
        CreateMap<Transaction, UpdateTransactionResponse>().ReverseMap();
        CreateMap<Transaction, DeleteTransactionResponse>().ReverseMap();
        
    }
}