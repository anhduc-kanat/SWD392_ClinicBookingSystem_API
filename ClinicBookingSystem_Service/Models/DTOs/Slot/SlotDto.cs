namespace ClinicBookingSystem_Service.Models.DTOs.Slot;

public class SlotDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public TimeSpan StartAt { get; set; }
    public TimeSpan EndAt { get; set; }
    public bool IsMorningShift { get; set; }
}