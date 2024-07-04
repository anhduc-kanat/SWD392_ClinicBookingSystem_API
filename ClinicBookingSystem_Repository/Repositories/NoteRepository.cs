using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class NoteRepository : BaseRepository<Note>, INoteRepository
{
    private readonly NoteDAO _noteDAO;
    public NoteRepository(NoteDAO noteDaO) : base(noteDaO)
    {
        _noteDAO = noteDaO;
    }

    public async Task<Note> GetNoteByAppointmentId(int appointmentId)
    {
        return await _noteDAO.GetNoteByAppointmentId(appointmentId);
    }
}