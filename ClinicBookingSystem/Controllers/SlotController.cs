using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly ISlotService _slotService;

        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Slot>>> GetSlots()
        {
            var slots = await _slotService.GetListSlots();
            return Ok(slots);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Slot>> GetSlot(int id)
        {
            var slot = await _slotService.GetSlot(id);
            if (slot == null)
            {
                return NotFound();
            }
            return Ok(slot);
        }

        [HttpPost]
        public async Task<ActionResult<Slot>> AddSlot(Slot slot)
        {
            var createdSlot = await _slotService.AddSlot(slot);
            return CreatedAtAction(nameof(GetSlot), new { id = createdSlot.Id }, createdSlot);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlot(int id, Slot slot)
        {
            if (id != slot.Id)
            {
                return BadRequest("Slot ID mismatch");
            }

            var updated = await _slotService.UpdateSlot(id, slot);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSlot(int id)
        {
            var removed = await _slotService.RemoveSlot(id);
            if (!removed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

