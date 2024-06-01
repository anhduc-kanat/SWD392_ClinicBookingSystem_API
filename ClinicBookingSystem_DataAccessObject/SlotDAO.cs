using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAcessObject.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingSystem_DataAccessObject
{
    public class SlotDAO
    {
        private readonly ClinicBookingSystemContext _context;

        public SlotDAO(ClinicBookingSystemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Slot>> GetSlotsAsync()
        {
            return await _context.Slots.ToListAsync();
        }
        //
        public async Task<Slot> GetSlotAsync(int id)
        {
            var slot = await _context.Slots.FindAsync(id);

            return slot ?? null;
        }

        public async Task<Slot> AddSlot(Slot slot)
        {
            if (slot == null)
            {
                return null;
            }

            _context.Slots.Add(slot);
            await _context.SaveChangesAsync();

            return slot;
        }

        public async Task<bool> UpdateSlot(int id, Slot slot)
        { 
            var existingSlot = await GetSlotAsync(id);

            existingSlot.Name = slot.Name;
            existingSlot.Description = slot.Description;
            existingSlot.StartAt = slot.StartAt;
            existingSlot.EndAt = slot.EndAt;
            existingSlot.Status = slot.Status;

            _context.Slots.Update(existingSlot);
            await _context.SaveChangesAsync();
            return true;
        }
        private bool SlotExists(int id)
        {
            return _context.Slots.Any(e => e.Id == id);
        }

        public async Task<bool> DeleteSlot(int id)
        {
            var existingSlot = await GetSlotAsync(id);
            if (existingSlot == null)
            {
                return false;
            }
            _context.Slots.Remove(existingSlot);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
