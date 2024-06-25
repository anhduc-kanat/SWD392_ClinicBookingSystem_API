using ClinicBookingSystem_BusinessObject.Enums;

namespace ClinicBookingSystem_BusinessObject.Entities;

public class AppointmentBusinessService : BaseEntities
{
    public AppointmentBusinessServiceStatus Status { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    public int CustomerAccountId { get; set; }
    public string CustomerAccountName { get; set; }
    public int DentistId { get; set; }
    public int DentistName { get; set; }
    public string ServiceName { get; set; }
    public long ServicePrice { get; set; }
    public ServiceType ServiceType { get; set; }
}