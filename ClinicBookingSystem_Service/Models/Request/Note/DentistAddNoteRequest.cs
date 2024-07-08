namespace ClinicBookingSystem_Service.Models.Request.Note;

public class DentistAddNoteRequest
{
    public string Content { get; set; }
    public int ResultId { get; set; }
    public int AppointmentBusinessServiceId { get; set; }

}