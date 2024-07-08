
using Microsoft.AspNetCore.SignalR;

namespace ClinicBookingSystem_Service.SignalR.SignalRHub;

public class AppointmentHub : Hub
{
    public async Task NotifyAppoointmentStatusChange(int appointmentId)
    {
        await Clients.All.SendAsync("ReceiveAppointmentStatusChange", appointmentId);
    }
}