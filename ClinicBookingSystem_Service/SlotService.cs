using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicBookingSystem_Repository;

namespace ClinicBookingSystem_Service
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _slotRepository = null;

        public SlotService(SlotRepository slotRepository)
        {
            _slotRepository ??= slotRepository;
        }
        public async Task<IEnumerable<Slot>> GetListSlots()
        {
            return await _slotRepository.GetListSlots();
        }

        public async Task<Slot> GetSlot(int id)
        {
            return await _slotRepository.GetSlot(id);
        }

        public async Task<Slot> AddSlot(Slot slot)
        {
            return await _slotRepository.AddSlot(slot);
        }

        public async Task<bool> RemoveSlot(int id)
        {
            return await _slotRepository.RemoveSlot(id);
        }

        public async Task<bool> UpdateSlot(int id, Slot slot)
        {
            return await _slotRepository.UpdateSlot(id, slot);
        }
    }
}
