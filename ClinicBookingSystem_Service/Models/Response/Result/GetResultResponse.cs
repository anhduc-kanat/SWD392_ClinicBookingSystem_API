using ClinicBookingSystem_Service.Models.Response.Medicine;

namespace ClinicBookingSystem_Service.Models.Response.Result;

public class GetResultResponse
{
    public int Id { get; set; }
    public string PrescriptionName { get; set; }
    public string PrescriptionDescription { get; set; }
    public int DentistId { get; set; }
    public string DentistName { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    public ICollection<GetMedicineResponse> Medicines { get; set; }
}