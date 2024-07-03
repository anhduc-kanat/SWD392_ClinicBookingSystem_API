using ClinicBookingSystem_Service.Models.Response.Medicine;
using ClinicBookingSystem_Service.Models.Response.Note;

namespace ClinicBookingSystem_Service.Models.Response.Result;

public class GetResultResponse
{
    public int Id { get; set; }
    public int UserTreatmentId { get; set; }
    public string UserTreatmentName { get; set; }
    public int UserAccountId { get; set; }
    public string UserAccountName { get; set; }
    
    public string PreScriptionName { get; set; }
    public string PreScriptionDescription { get; set; }
    public ICollection<GetMedicineResponse> Medicines { get; set; }
    public ICollection<GetNoteResponse> Notes { get; set; }
}