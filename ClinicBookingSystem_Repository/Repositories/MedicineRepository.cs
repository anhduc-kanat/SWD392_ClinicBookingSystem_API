using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class MedicineRepository : BaseRepository<Medicine>, IMedicineRepository
{
    private readonly MedicineDAO _medicineDao;
    public MedicineRepository(MedicineDAO medicineDao) : base(medicineDao)
    {
        _medicineDao = medicineDao;
    }
}