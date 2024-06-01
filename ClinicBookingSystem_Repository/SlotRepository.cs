using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;

namespace ClinicBookingSystem_Repository
{
    public class SlotRepository : ISlotRepository
    {
        private readonly SlotDAO slotDAO = null;
        public SlotRepository(SlotDAO slotDao)
        {
            slotDAO ??= slotDao;
        }

        public async Task<IEnumerable<Slot>> GetListSlots()
        {
            return await slotDAO.GetSlotsAsync();
        }

        public async Task<Slot> GetSlot(int id)
        {
            return await slotDAO.GetSlotAsync(id);
        }

        public async Task<Slot> AddSlot(Slot slot)
        {
            return await slotDAO.AddSlot(slot);
        }

        public async Task<bool> RemoveSlot(int id)
        {
            return await slotDAO.DeleteSlot(id);
        }

        public async Task<bool> UpdateSlot(int id, Slot slot)
        {
            return await slotDAO.UpdateSlot(id, slot);
        }
    }
}
