using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem_DataAccessObject;

public class TransactionDAO : BaseDAO<Transaction>
{
    private readonly ClinicBookingSystemContext _dbContext;
    public TransactionDAO(ClinicBookingSystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Transaction> GetTransactionByAppointmentId(int appointmentId)
    {
        return await GetQueryableAsync()
            .Where(p => p.Appointment.Id == appointmentId)
            .FirstOrDefaultAsync();
    }
}