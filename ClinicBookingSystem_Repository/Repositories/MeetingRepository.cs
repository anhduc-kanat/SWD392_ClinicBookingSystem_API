using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class MeetingRepository : BaseRepository<Meeting>, IMeetingRepository
{
    private readonly MeetingDAO _meetingDao;
    public MeetingRepository(MeetingDAO meetingDao) : base(meetingDao)
    {
        _meetingDao = meetingDao;
    }

    public async Task<IEnumerable<Meeting>> GetMeetingByToday(DateTime dateTime)
    {
        return await _meetingDao.GetMeetingByToday(dateTime);
    }

    public async Task<Meeting> GetMeetingById(int id)
    {
        return await _meetingDao.GetMeetingById(id);
    }

    public async Task<Meeting> GetTreatmentMeetingQueue(int appointmentId, DateTime date)
    {
        return await _meetingDao.GetTreatmentMeetingQueue(appointmentId, date);
    }
    
}