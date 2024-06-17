using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.IRepositories;

public interface IAppointmentRepository : IBaseRepository<Appointment>
{
    Task<IEnumerable<Appointment>> GetAllAppointment();
    Task<Appointment> GetAppointmentById(int Id);
    Task<IEnumerable<Appointment>> GetAllAppointmentPagination(int pageNumber, int pageSize);
    Task<IEnumerable<Appointment>> GetAppointmentByUserId(int userId, int pageNumber, int pageSize);
    Task<int> CountUserAppointment(int userId);
}