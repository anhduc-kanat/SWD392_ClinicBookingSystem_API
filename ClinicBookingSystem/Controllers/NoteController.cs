using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Note;
using ClinicBookingSystem_Service.Models.Response.Note;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers;

[ApiController]
[Route("api/note")]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;
    public NoteController(INoteService noteService) 
    {
        _noteService = noteService;
    }
    
    [HttpPost]
    [Route("dentist-add-note")]
    [Authorize(Roles = "DENTIST")]
    public async Task<BaseResponse<DentistAddNoteResponse>> DentistAddNote([FromBody] DentistAddNoteRequest request)
    {
        var dentistId = int.Parse(User.Claims.First(c => c.Type == "userId").Value);
        return await _noteService.DentistAddNote(dentistId, request);
    }
}