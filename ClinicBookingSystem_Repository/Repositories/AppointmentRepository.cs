using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
{
    private readonly AppointmentDAO _appointmentDAO;
    public AppointmentRepository(AppointmentDAO appointmentDAO) : base(appointmentDAO)
    {
        _appointmentDAO = appointmentDAO;
    }
    public async Task<IEnumerable<Appointment>> GetAllAppointment()
    {
        return await _appointmentDAO.GetAllAppointment();
    }
    public async Task<Appointment> GetAppointmentById(int Id)
    {
        return await _appointmentDAO.GetAppointmentById(Id);
    }
    public async Task<IEnumerable<Appointment>> GetAllAppointmentPagination(int pageNumber, int pageSize)
    {
        return await _appointmentDAO.GetAllAppointmentPagination(pageNumber, pageSize);
    }
}