using ClinicBookingSystem_BusinessObject.Entities;
using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IRepositories;

namespace ClinicBookingSystem_Repository.Repositories;

public class ResultRepository : BaseRepository<Result>, IResultRepository
{
    private readonly ResultDAO _resultDAO;
    public ResultRepository(ResultDAO resultDAO) : base(resultDAO)
    {
        _resultDAO = resultDAO;
    }

    public async Task<Result> GetResultByAppointmentId(int appointmentId)
    {
        return await _resultDAO.GetResultByAppointmentId(appointmentId);
    }

    public async Task<Result> GetResultById(int resultId)
    {
        return await _resultDAO.GetResultById(resultId);
    }
}