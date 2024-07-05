namespace ClinicBookingSystem_BusinessObject.Entities;

public class Note : BaseEntities
{
    public string Content { get; set; }
    public int? DentistId { get; set; }
    public string? DentistName { get; set; }
    public string? ServiceName { get; set; }
    public Result? Result { get; set; }
}