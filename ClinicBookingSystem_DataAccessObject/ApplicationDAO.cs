using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAcessObject.DBContext;

namespace ClinicBookingSystem_DataAccessObject;

public class ApplicationDAO : BaseDAO<Application>
{
    private readonly ClinicBookingSystemContext _dbContext;

    public ApplicationDAO(ClinicBookingSystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}