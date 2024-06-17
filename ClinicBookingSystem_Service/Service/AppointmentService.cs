using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.DTOs.Appointment;
using ClinicBookingSystem_Service.Models.Enums;
using ClinicBookingSystem_Service.Models.Pagination;
using ClinicBookingSystem_Service.Models.Request.Appointment;
using ClinicBookingSystem_Service.Models.Response.Appointment;
namespace ClinicBookingSystem_Service.Service;

public class AppointmentService : IAppointmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseResponse<IEnumerable<GetAppointmentResponse>>> GetAllAppointments()
    {
        var appointments = await _unitOfWork.AppointmentRepository.GetAllAppointment();
        var result = _mapper.Map<IEnumerable<GetAppointmentResponse>>(appointments);
        return new BaseResponse<IEnumerable<GetAppointmentResponse>>("Get all appointments successfully", StatusCodeEnum.OK_200, result);
    }

    public async Task<PaginationResponse<GetAppointmentResponse>> GetAllAppointmentsPagination(int pageNumber, int pageSize)
    {
        var appointments = await _unitOfWork.AppointmentRepository.GetAllAppointmentPagination(pageNumber, pageSize);
        int count = await _unitOfWork.AppointmentRepository.CountAllAsync();
        var result = _mapper.Map<IList<GetAppointmentResponse>>(appointments);
        return new PaginationResponse<GetAppointmentResponse>(
            "Get all appointments successfully",
            StatusCodeEnum.OK_200,
            result,
            pageNumber,
            pageSize,
            count
        );
    }
    public async Task<BaseResponse<GetAppointmentResponse>> GetAppointmentById(int id)
    {
        Appointment appointment = await _unitOfWork.AppointmentRepository.GetAppointmentById(id);
        var result = _mapper.Map<GetAppointmentResponse>(appointment);
        return new BaseResponse<GetAppointmentResponse>("Get appointment by id successfully", StatusCodeEnum.OK_200, result);
    }
    
    public async Task<BaseResponse<CreateAppointmentResponse>> CreateAppointment(CreateAppointmentRequest request)
    {
        //Appointment appointment = _mapper.Map<Appointment>(request);
        DateTime date = new DateTime(request.Date.Year, request.Date.Month, request.Date.Day, 0, 0, 0);
        User patient = await _unitOfWork.UserRepository.GetByIdAsync(request.PatientId);
        User dentist = await _unitOfWork.DentistRepository.GetByIdAsync(request.DentistId);
        Slot slot = await _unitOfWork.SlotRepository.GetByIdAsync(request.SlotId);
        BusinessService businessService = await _unitOfWork.ServiceRepository.GetByIdAsync(request.ServiceId);
        ICollection<User> users = new List<User>();
        users.Add(patient);
        users.Add(dentist);
        AppointmentDto appointmentDto = new AppointmentDto
        {  
            Date = date,
            IsPeriod = request.IsPeriod,
            ReExamUnit = request.ReexamUnit,
            ReExamNumber = request.ReexamNumber,
            IsTreatment = request.IsTreatment,
            BusinessService = businessService,
            Slot = slot,
            Users = users
        };
        var appointment = _mapper.Map<Appointment>(appointmentDto);
        await _unitOfWork.AppointmentRepository.AddAsync(appointment);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<CreateAppointmentResponse>(appointment);
        return new BaseResponse<CreateAppointmentResponse>("Create appointment successfully", StatusCodeEnum.Created_201, result);
    }

    public async Task<BaseResponse<CustomerBookingAppointmentResponse>> UserBookingAppointment(int userId,
        CustomerBookingAppointmentRequest request)
    {
        Slot slot = await _unitOfWork.SlotRepository.GetByIdAsync(request.SlotId);
        DateTime date = new DateTime(request.Date.Year, request.Date.Month, request.Date.Day, slot.StartAt.Hours, slot.StartAt.Minutes, slot.StartAt.Seconds);
        User userBooking = await _unitOfWork.UserRepository.GetByIdAsync(userId);
        UserProfile patient = await _unitOfWork.UserProfileRepository.GetByIdAsync(request.PatientId);
        User dentist = await _unitOfWork.DentistRepository.GetByIdAsync(request.DentistId);
        IEnumerable<Slot> dentistAvailableSlot = await _unitOfWork.SlotRepository.CheckAvailableSlot(dentist.Id, date);
        if (!dentistAvailableSlot.Any(a => a.Id == slot.Id)) throw new Exception("This slot is unavailable");
        BusinessService businessService = await _unitOfWork.ServiceRepository.GetByIdAsync(request.ServiceId);
        ICollection<User> users = new List<User>();
        users.Add(userBooking);
        users.Add(dentist);
        AppointmentDto appointmentDto = new AppointmentDto
        {
            Date = date,
            IsPeriod = false,
            ReExamUnit = 0,
            ReExamNumber = 0,
            IsTreatment = false,
            BusinessService = businessService,
            Slot = slot,
            Users = users
        };
        var appointment = _mapper.Map<Appointment>(appointmentDto);
        appointment.UserTreatmentName = patient.FirstName + patient.LastName;
        appointment.UserBookingName = userBooking.FirstName + patient.LastName;
        await _unitOfWork.AppointmentRepository.AddAsync(appointment);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<CustomerBookingAppointmentResponse>(appointment);
        return new BaseResponse<CustomerBookingAppointmentResponse>("User booking appointment successfully", StatusCodeEnum.Created_201, result);
    }

    
    public async Task<BaseResponse<CustomerBookingAppointmentResponse>> StaffBookingAppointmentForUser(
        StaffBookingAppointmentForCustomerRequest request)
    {
        Slot slot = await _unitOfWork.SlotRepository.GetByIdAsync(request.SlotId);
        DateTime date = new DateTime(request.Date.Year, request.Date.Month, request.Date.Day, slot.StartAt.Hours, slot.StartAt.Minutes, slot.StartAt.Seconds);
        User patient = await _unitOfWork.UserRepository.GetByIdAsync(request.PatientId);
        User dentist = await _unitOfWork.DentistRepository.GetByIdAsync(request.DentistId);
        IEnumerable<Slot> dentistAvailableSlot = await _unitOfWork.SlotRepository.CheckAvailableSlot(dentist.Id, date);
        if (!dentistAvailableSlot.Any(a => a.Id == slot.Id)) throw new Exception("This slot is unavailable");
        BusinessService businessService = await _unitOfWork.ServiceRepository.GetByIdAsync(request.ServiceId);
        ICollection<User> users = new List<User>();
        users.Add(patient);
        users.Add(dentist);
        AppointmentDto appointmentDto = new AppointmentDto
        {
            Date = date,
            IsPeriod = false,
            ReExamUnit = 0,
            ReExamNumber = 0,
            IsTreatment = false,
            BusinessService = businessService,
            Slot = slot,
            Users = users
        };
        var appointment = _mapper.Map<Appointment>(appointmentDto);
        await _unitOfWork.AppointmentRepository.AddAsync(appointment);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<CustomerBookingAppointmentResponse>(appointment);
        return new BaseResponse<CustomerBookingAppointmentResponse>("User booking appointment successfully", StatusCodeEnum.Created_201, result);
    }
    public async Task<BaseResponse<UpdateAppointmentResponse>> UpdateAppointment(int id, UpdateAppointmentRequest request)
    {
        Appointment appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);
        _mapper.Map(request, appointment);
        await _unitOfWork.AppointmentRepository.UpdateAsync(appointment);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<UpdateAppointmentResponse>(appointment);
        return new BaseResponse<UpdateAppointmentResponse>("Update appointment successfully", StatusCodeEnum.OK_200, result);
    }
    public async Task<BaseResponse<DeleteAppointmentResponse>> DeleteAppointment(int id)
    {
        Appointment appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);
        await _unitOfWork.AppointmentRepository.DeleteAsync(appointment);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<DeleteAppointmentResponse>(appointment);
        return new BaseResponse<DeleteAppointmentResponse>("Delete appointment successfully", StatusCodeEnum.OK_200, result);
    }
    
    public async Task<PaginationResponse<UserGetAppointmentResponse>> GetAppointmentByUserId(int userId, int pageNumber, int pageSize)
    {
        var appointments = await _unitOfWork.AppointmentRepository.GetAppointmentByUserId(userId, pageNumber, pageSize);
        int count = await _unitOfWork.AppointmentRepository.CountUserAppointment(userId);
        var result = _mapper.Map<IList<UserGetAppointmentResponse>>(appointments);
        return new PaginationResponse<UserGetAppointmentResponse>(
            "Get all appointments successfully",
            StatusCodeEnum.OK_200,
            result,
            pageNumber,
            pageSize,
            count
        );
    }
}