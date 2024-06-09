using AutoMapper;
using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_Service.Models.Request.MedicalRecord;
using ClinicBookingSystem_Service.Models.Request.Relative;
using ClinicBookingSystem_Service.Models.Request.UserProfile;
using ClinicBookingSystem_Service.Models.Response.MedicalRecord;
using ClinicBookingSystem_Service.Models.Response.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBookingSystem_Service.Mapping
{
    public class MappingMedicalRecord: Profile
    {
        public MappingMedicalRecord()
        {
            CreateMap<CreateMedicalRecordRequest, MedicalRecord>().ReverseMap();
            CreateMap<UpdateMedicalRecordRequest, MedicalRecord>().ReverseMap();
            CreateMap<MedicalRecord, DeleteMedicalRecordResponse>();
            CreateMap<MedicalRecord, UpdateMedicalRecordResponse>();
            CreateMap<MedicalRecord, GetMedicalReportResponse>();
            CreateMap<MedicalRecord, GetMedicalReportResponse>();

        }
    }
}
