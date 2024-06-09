namespace ClinicBookingSystem_Service.Models.Request.Medicine;

public class CreateMedicineRequest
{
    public string name { get; set; }
    public int? DosageUnitPerDayRecommend { get; set; }
    public string? Description { get; set; }
    public int? DosagePerDayActual { get; set; }
    public int? Total { get; set; }
}