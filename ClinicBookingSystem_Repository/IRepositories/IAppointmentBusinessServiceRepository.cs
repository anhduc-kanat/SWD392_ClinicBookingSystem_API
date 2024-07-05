using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IBaseRepository;

namespace ClinicBookingSystem_Repository.IRepositories;

public interface IAppointmentBusinessServiceRepository : IBaseRepository<AppointmentBusinessService>
{
    Task<IEnumerable<AppointmentBusinessService>> GetAppointmentBusinessServiceByAppointmentId(int appointmentId);

    Task<AppointmentBusinessService> GetAppointmentBusinessServiceByDentistInThatTask(int dentistId,
        int appointmentBusinessServiceId);

    Task<IEnumerable<AppointmentBusinessService>> GetUnPaidAppointmentBusiness(int appointmentId);
}