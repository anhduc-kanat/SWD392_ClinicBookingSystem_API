using ClinicBookingSystem_BusinessObject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClinicBookingSystem_BusinessObject.Entities
{
    public class User : BaseEntities
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public Boolean? EmailConfirmed { get; set; } = false;
        public Boolean? PhoneConfirmed { get; set; } = false;
        [JsonIgnore]
        public string? EmailCode { get; set; }
        public string? Address { get; set; }
        [JsonIgnore]
        public string? PhoneCode { get; set; }
        public string PhoneNumber {  get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //Các thuộc tính thuộc lịch nghỉ làm của nhân viên
        public int? TotalDateOff {  get; set; }
        public int? DateOffCount {  get; set; }
        public int? TotalEmergencyDateOffAttempt { get; set; }
        public int? EmergencyDateOffAttemptCount { get; set; }
        public Boolean? IsOnDateOff { get; set; }
        public JobStatus? JobStatus {  get; set; }
        public DateTime? StartDateOff {  get; set; }
        public DateTime? EndDateOff { get; set;}

        //Role

        public Role? Role { get; set; }
        
        //Appointment
        public ICollection<Appointment>? Appointments { get; set; }
        //Salary
        public Salary? Salary { get; set; }
        //Specification
        public ICollection<Specification>? Specifications { get; set; }
        //Clinic
        public ICollection<Clinic>? Clinics { get; set; }
        
        //Relative
        public RelativeType? RelativeType { get; set; }
        public ICollection<Relative>? Relatives { get; set; }
        //Claim
        public ICollection<Claim>? Claims { get; set; }
        //Apllication
        public ICollection<Application> Applications { get; set; }
        //Medical Record
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
        //Billing
        public ICollection<Billing> Billings { get; set; }
        //Order
        public ICollection<Order> Orders { get; set; }
    }
}
