using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicBookingSystem_BusinessObject.Entities;

namespace ClinicBookingSystem_Repository
{
    public interface ISlotRepository
    {
        public Task<IEnumerable<Slot>> GetListSlots();
        public Task<Slot> GetSlot(int id);
        public Task<Slot> AddSlot(Slot slot);
        public Task<bool> RemoveSlot(int id);
        public Task<bool> UpdateSlot(int id, Slot slot);
    }
}
