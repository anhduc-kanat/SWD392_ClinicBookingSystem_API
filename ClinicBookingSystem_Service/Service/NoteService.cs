using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Enums;
using ClinicBookingSystem_Service.Models.Request.Note;
using ClinicBookingSystem_Service.Models.Response.Note;

namespace ClinicBookingSystem_Service.Service;

public class NoteService : INoteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public NoteService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseResponse<DentistAddNoteResponse>> DentistAddNote(int dentistId, DentistAddNoteRequest request)
    {
        /*var appointmentBusinessService =
            await _unitOfWork.AppointmentBusinessServiceRepository.GetAppointmentBusinessServiceByDentistInThatTask(
                dentistId, request.AppointmentBusinessServiceId);
        
        Note note = _mapper.Map<Note>(request);
        Result appointmentResult = await _unitOfWork.ResultRepository.GetResultById(request.ResultId);
        _mapper.Map(appointmentBusinessService, note);
        
        note.Result = appointmentResult;
        await _unitOfWork.NoteRepository.AddAsync(note);
        await _unitOfWork.SaveChangesAsync();
        var result = _mapper.Map<DentistAddNoteResponse>(note);
        return new BaseResponse<DentistAddNoteResponse>("Note added successfully", StatusCodeEnum.Created_201, result);*/
        throw new NotImplementedException();
    }
}