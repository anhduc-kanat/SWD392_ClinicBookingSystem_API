using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class ClinicOwnerRepository : BaseRepository<User>, IClinicOwnerRepository
{
    private readonly ClinicOwnerDAO _clinicOwnerDAO;
    
    public ClinicOwnerRepository(ClinicOwnerDAO clinicOwnerDAO) : base(clinicOwnerDAO)
    {
        _clinicOwnerDAO = clinicOwnerDAO;
    }

    public async Task<IEnumerable<User>> GetClinicOwnerByRole()
    {
        return await _clinicOwnerDAO.GetClinicOwnerByRole();
    }
}