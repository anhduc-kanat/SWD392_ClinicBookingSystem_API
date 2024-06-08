using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    private readonly TransactionDAO _transactionDao;
    public TransactionRepository(TransactionDAO transactionDao) : base(transactionDao)
    {
        _transactionDao = transactionDao;
    }
}