using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Note;
using ClinicBookingSystem_Service.Models.Response.Note;

namespace ClinicBookingSystem_Service.IService;

public interface INoteService
{
    Task<BaseResponse<DentistAddNoteResponse>> DentistAddNote(int dentistId, DentistAddNoteRequest request);
}