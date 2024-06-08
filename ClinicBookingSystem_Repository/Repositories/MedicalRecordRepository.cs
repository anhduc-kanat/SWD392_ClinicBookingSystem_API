using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class MedicalRecordRepository : BaseRepository<MedicalRecord>, IMedicalRecordRepository
{
    private readonly MedicalRecordDAO _medicalRecordDao;
    public MedicalRecordRepository(MedicalRecordDAO medicalRecordDao) : base(medicalRecordDao)
    {
        _medicalRecordDao = medicalRecordDao;
    }
}