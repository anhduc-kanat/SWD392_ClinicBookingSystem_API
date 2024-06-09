using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Models.BaseResponse;
using ClinicBookingSystem_Service.Models.Request.Slot;
using ClinicBookingSystem_Service.Models.Response.Slot;
using ClinicBookingSystem_Service.Models.Response.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers
{
    [Route("api/slot")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly ISlotService _slotService;

        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [HttpGet]
        [Route("get-all-slots")]
        public async Task<ActionResult<BaseResponse<IEnumerable<SlotResponse>>>> GetSlots()
        {
            var slots = await _slotService.GetAllSlots();
            return Ok(slots);
        }

        [HttpGet]
        [Route("get-slot-by-id/{id}")]
        public async Task<ActionResult<BaseResponse<SlotResponse>>> GetSlot(int id)
        {
            var slot = await _slotService.GetSlotById(id);
            
            return Ok(slot);
        }

        [HttpPost]
        [Route("create-slot")]
        public async Task<ActionResult<BaseResponse<SlotResponse>>> AddSlot([FromBody] CreateNewSlotRequest request)
        {
            var createdSlot = await _slotService.CreateSlot(request);
            return createdSlot;
        }

        [HttpPut]
        [Route("update-slot/{id}")]
        public async Task<ActionResult<BaseResponse<SlotResponse>>> UpdateSlot(int id,[FromBody] UpdateSlotRequest request)
        {
            return await _slotService.UpdateSlot(id, request);
        }

        [HttpDelete]
        [Route("delete-slot/{id}")]
        public async Task<ActionResult<BaseResponse<SlotResponse>>> DeleteSlot(int id)
        {
            return await _slotService.DeleteSlot(id);
        }
    }
}

