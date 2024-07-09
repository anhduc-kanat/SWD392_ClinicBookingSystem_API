using ClinicBookingSystem_BusinessObject.Enums;
using ClinicBookingSystem_Repository.IRepositories;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Quartz;

namespace ClinicBookingSystem_Service.Scheduler;

public class CheckMeetingJob : IJob
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ILogger<CheckMeetingJob> _logger;
    public CheckMeetingJob(IUnitOfWork unitOfWork, ILogger<CheckMeetingJob> logger)
    {
        this.unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        var meetings = await unitOfWork.MeetingRepository.GetMeetingByToday(DateTime.Now);
        if (meetings.IsNullOrEmpty()) return;
        foreach (var meeting in meetings)
        {
            _logger.LogInformation($"{meeting.Id} - {meeting.Status}");
            if (meeting.Status != MeetingStatus.Future) continue;
            meeting.Status = MeetingStatus.Waiting;
            await unitOfWork.MeetingRepository.UpdateAsync(meeting);
        }
        await unitOfWork.SaveChangesAsync();
        _logger.LogInformation("Check MeetingStatus has been done.");
        
    }
}