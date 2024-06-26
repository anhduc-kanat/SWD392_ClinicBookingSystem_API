using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;

namespace ClinicBookingSystem_Service.Service;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    public PaymentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<String> CreateVnPayPaymentUrl(int appointmentId)
    {
        //nhan vo appointment => list ra appointmentservice => tinh tong tien cua cac appointmentservice
        Appointment appointment = await _unitOfWork.AppointmentRepository.GetAppointmentById(1);
        return appointment.ToString();
    }
}