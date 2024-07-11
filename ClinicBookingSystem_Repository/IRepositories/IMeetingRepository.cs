using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.IRepositories;

public interface IMeetingRepository : IBaseRepository<Meeting>
{
    Task<IEnumerable<Meeting>> GetMeetingByToday(DateTime dateTime);
    Task<Meeting> GetMeetingById(int id);
    Task<Meeting> GetTreatmentMeetingQueue(int appointmentId, DateTime date);
    Task<Meeting> GetTreatmentMeetingQueueByMeetingId(int meetingId, DateTime date);
}