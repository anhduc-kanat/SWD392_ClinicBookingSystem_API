using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem_DataAccessObject;

public class NoteDAO : BaseDAO<Note>
{
    private readonly ClinicBookingSystemContext _dbContext;
    public NoteDAO(ClinicBookingSystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<Note> GetNoteByAppointmentId(int appointmentId)
    {
        return GetQueryableAsync()
            .Include(p => p.Result)
            .FirstOrDefaultAsync(p => p.Result.AppointmentId == appointmentId);
    }
}