namespace ClinicBookingSystem_Service.Models.Response.Medicine;

public class GetMedicineResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DosageUnitPerDayRecommend { get; set; }
    public string Description { get; set; }
    public int DosagePerDayActual { get; set; }
    public int Total { get; set; }
}