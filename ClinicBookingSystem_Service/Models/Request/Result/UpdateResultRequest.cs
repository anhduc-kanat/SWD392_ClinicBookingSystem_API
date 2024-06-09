namespace ClinicBookingSystem_Service.Models.Request.Result;

public class UpdateResultRequest
{
    public string PrescriptionName { get; set; }
    public string? PrescriptionDescription { get; set; }
    public int? DentistId { get; set; }
    public string? DentistName { get; set; }
    public int? PatientId { get; set; }
    public string? PatientName { get; set; }
    public int? AppointmentId { get; set; }
    public IEnumerable<int>? MedicineId { get; set; } 
}