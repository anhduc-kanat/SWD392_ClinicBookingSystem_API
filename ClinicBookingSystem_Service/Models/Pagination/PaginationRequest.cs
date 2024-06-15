namespace ClinicBookingSystem_Service.Models.Pagination;

public class PaginationRequest
{
    private int _pageNumber;
    private int _pageSize;
    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1 ? 1 : value;
    }
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > 100 ? 100 : value;
    }
}