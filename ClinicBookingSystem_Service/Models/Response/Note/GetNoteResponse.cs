namespace ClinicBookingSystem_Service.Models.Response.Note;

public class GetNoteResponse
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int DentistId { get; set; }
    public string DentistName { get; set; }
    public string ServiceName { get; set; }
}