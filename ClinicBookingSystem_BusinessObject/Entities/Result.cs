using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_BusinessObject.Entities
{
    public class Result : BaseEntities
    {
        [Key]
        public int Id { get; set; }
        public int DentistId { get; set; }
        public int PatientId { get; set; }
        public string PreScriptionName { get; set; }
        public string PreScriptionDescription { get; set; }
        //Appointment
        public Appointment Appointment { get; set; }

        //Medical Record
        public MedicalRecord MedicalRecord { get; set; }
        //Medicine
        public ICollection<Medicine> Medicines { get; set; }
    }
}
