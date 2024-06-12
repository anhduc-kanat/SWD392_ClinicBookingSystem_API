using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_BusinessObject.IEntities
{
    public interface IBaseEntities
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
        bool IsDelete { get; set; }
        bool IsActive { get; set; }
    }
}
