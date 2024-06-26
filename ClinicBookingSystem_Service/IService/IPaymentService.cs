namespace ClinicBookingSystem_Service.IService;

public interface IPaymentService
{
    Task<String> CreateVnPayPaymentUrl(int appointmentId);

}