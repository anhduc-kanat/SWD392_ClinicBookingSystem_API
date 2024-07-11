using ClinicBookingSystem_BusinessObject.Enums;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.CustomException;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.Enums;
using ClinicBookingSystem_Service.RabbitMQ.IService;

namespace ClinicBookingSystem_Service.Service;

public class QueueService : IQueueService
{
    private readonly IRabbitMQService _rabbitMqService;
    private readonly IUnitOfWork _unitOfWork;
    public QueueService(IRabbitMQService rabbitMqService,
        IUnitOfWork unitOfWork)
    {
        _rabbitMqService = rabbitMqService;
        _unitOfWork = unitOfWork;
    }
    
    public async Task PublishAppointmentToQueue(int appointmentId, int dentistId)
    {
        var appointment = await _unitOfWork.AppointmentRepository.GetAppointmentById(appointmentId);
        if (appointment == null) throw new CoreException("Appointment not found", StatusCodeEnum.BadRequest_400);
        if(appointment.Status != AppointmentStatus.Waiting) 
            throw new CoreException("Appointment is not in waiting for queue", StatusCodeEnum.BadRequest_400);
        
        /*
        var appointmentBusinessService = appointment.AppointmentBusinessServices.FirstOrDefault(p =>
            p.Meetings.Any(p => p.Date.Value.Year == DateTime.Now.Year &&
                                 p.Date.Value.Month == DateTime.Now.Month &&
                                 p.Date.Value.Day == DateTime.Now.Day &&
                                 p.Status == MeetingStatus.CheckIn) && p.ServiceType == ServiceType.Treatment);*/
        var meeting = await _unitOfWork.MeetingRepository.GetTreatmentMeetingQueue(appointmentId, DateTime.Now);
        if(meeting == null)
            throw new CoreException("There is no AppointmentBusinessService suitable", StatusCodeEnum.BadRequest_400);
        
        var dentist = await _unitOfWork.DentistRepository.GetDentistById(dentistId);
        if(dentist == null) throw new CoreException("Dentist not found", StatusCodeEnum.BadRequest_400);
        if(!dentist.BusinessServices.Any(p => p.Id == meeting.AppointmentBusinessService.BusinessService.Id))
            throw new CoreException("Dentist not provide this service", StatusCodeEnum.BadRequest_400);
        string dentistName = dentist.FirstName + " " + dentist.LastName;
        _rabbitMqService.PublishMessage(dentistName, appointmentId.ToString());
        meeting.Status = MeetingStatus.InQueue;
        appointment.Status = AppointmentStatus.OnTreatment;
        await _unitOfWork.AppointmentRepository.UpdateAsync(appointment);
        await _unitOfWork.MeetingRepository.UpdateAsync(meeting);
        await _unitOfWork.SaveChangesAsync();
    }
}