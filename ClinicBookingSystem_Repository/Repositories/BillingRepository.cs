using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class BillingRepository : BaseRepository<Billing>, IBillingRepository 
{
    private readonly BillingDAO _billingDao;
    public BillingRepository(BillingDAO billingDao) : base(billingDao)
    {
        _billingDao = billingDao;
    }
}